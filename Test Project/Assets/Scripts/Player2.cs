﻿using System.Collections;
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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Vertical") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal * 2, 0);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        //float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        //transform.Translate(0, 0, vertical);

        if (Input.GetKey("up"))
        {
            if (charge < 200)
            {
                charge += 1;
            }
        }
        if (Input.GetKeyUp("up"))
        {
            rb.AddForce(transform.forward * charge * thrust);
            charge = 0;
        }

        if (transform.position.y < -5)
        {
            transform.position = new Vector3(0, 5, 0);
        }



        boostSlider.value = charge;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jump_Panel")
        {
            rb.AddForce(transform.up * 3000);
        }
    }
}
