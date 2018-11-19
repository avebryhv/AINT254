using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private float movementSpeed = 10;
    public float turningSpeed = 60;
    public float thrust;
    public int score = 0;

    [Range(0, 200f)]
    public float charge;

    public Rigidbody rb;
    public Slider boostSlider;
    public float V;
    public Camera p1Cam;
    public ParticleSystem fire;
    public ParticleSystem boost;
    public ParticleSystem glow;    
    AudioSource audioPlayer;
    public AudioSource boostPlayer;

    void Start() {
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal * 2, 0);
        //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        //float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        //transform.Translate(0, 0, vertical);

        if (Input.GetKeyDown("w"))
        {
            boostPlayer.Play();
            glow.Play();
        }
        if (Input.GetKey("w"))
        {
            if (charge < 200)
            {
                charge += 1 * Time.deltaTime * 120;
            }
            p1Cam.fieldOfView = Mathf.Lerp(p1Cam.fieldOfView, 60 - (charge / 20), Time.deltaTime);
            var main = glow.main;
            main.startSpeed = main.startSpeed = (charge / 200 * 12);
            //rb.AddForce(transform.forward * thrust);
        }
        if (Input.GetKeyUp("w"))
        {
            boostPlayer.Stop();
            audioPlayer.Play();
            var main = boost.main;
            main.startSpeed = (charge / 200 * 12) + 3;
            boost.Play();
            glow.Stop();
            rb.AddForce(transform.forward * charge * thrust);
            charge = 0;
        }
        if (transform.position.y < -5)
        {
            transform.position = new Vector3(0, 5, 0);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            charge = 0;
            score++;
        }
        if (Input.GetKeyDown("s"))
        {
            charge = 0;
        }

        V = rb.velocity.magnitude;
        if (V >= 30)
        {
            p1Cam.fieldOfView = Mathf.Lerp(p1Cam.fieldOfView, 60 + (V * 1.5f) - 30, Time.deltaTime);
            fire.Play();
        }
        else if(charge == 0)
        {
            p1Cam.fieldOfView = Mathf.Lerp(p1Cam.fieldOfView, 60, Time.deltaTime);
            fire.Stop();
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
