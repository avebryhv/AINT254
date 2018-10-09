using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 60f, ForceMode.Impulse);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
