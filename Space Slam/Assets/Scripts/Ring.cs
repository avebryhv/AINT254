using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {

    public float turnSpeed = 1;
    public float maxTurnSpeed = 3;

	// Use this for initialization
	void Start () {
        turnSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        turnSpeed = Mathf.Lerp(turnSpeed, maxTurnSpeed, Time.deltaTime * 0.5f);
        transform.Rotate(0, 0, turnSpeed);
	}
}
