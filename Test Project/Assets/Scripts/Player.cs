using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private float movementSpeed = 10;
    public float turningSpeed = 60;
    public float thrust;
    public float charge;
    public Rigidbody rb;
    public Slider boostSlider;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        //float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        //transform.Translate(0, 0, vertical);

        if (Input.GetKey("e"))
        {
            charge += 1;
            //rb.AddForce(transform.forward * thrust);
        }
        if (Input.GetKeyUp("e"))
        {
            rb.AddForce(transform.forward * charge * thrust);
            charge = 0;
        }
        boostSlider.value = charge;

    }
}
