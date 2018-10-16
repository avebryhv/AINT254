using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour {

    private float movementSpeed = 10;
    public float turningSpeed = 60;
    public float thrust;
    public float charge;
    public Rigidbody rb;
    public Slider boostSlider;
    public int score = 0;

    //AI only variables
    public bool AI = false;
    public GameObject player1;
    int chargeLimit = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (PlayerPrefs.GetInt("Players") == 1)
        {
            AI = true;
        }
        else
        {
            AI = false;
        }
    }

    void Update()
    {
        if (AI)
        {
            //Vector3.RotateTowards(transform.right, player1.transform.position, turningSpeed * Time.deltaTime, 0.0f);
            //Quaternion.RotateTowards(transform.rotation, player1.transform, turningSpeed * Time.deltaTime);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((player1.transform.position - transform.position).normalized), Time.deltaTime * 10);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

            charge += 1 * Time.deltaTime * 120;
            if (charge > chargeLimit)
            {
                rb.AddForce(transform.forward * charge * thrust);
                charge = 0;
                chargeLimit = Random.Range(60, 100);
            }
        }
        else
        {
            float horizontal = Input.GetAxis("Vertical") * turningSpeed * Time.deltaTime;
            transform.Rotate(0, horizontal * 2, 0);
            //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            //float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
            //transform.Translate(0, 0, vertical);

            if (Input.GetKey("up"))
            {
                if (charge < 200)
                {
                    charge += 1 * Time.deltaTime * 120;
                }
            }
            if (Input.GetKeyUp("up"))
            {
                rb.AddForce(transform.forward * charge * thrust);
                charge = 0;
            }
        }

        

        if (transform.position.y < -5)
        {
            transform.position = new Vector3(0, 5, 0);
            score++;
        }



        boostSlider.value = charge;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jump_Panel")
        {
            rb.AddForce(transform.up * 2000);
        }
    }
}
