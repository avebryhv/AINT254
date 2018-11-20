using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

    public float time;

	// Use this for initialization
	void Start () {
        Invoke("Destroy", time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Destroy()
    {
        Object.Destroy(gameObject);
    }
}
