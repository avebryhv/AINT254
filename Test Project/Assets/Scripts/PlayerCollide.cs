using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour {

    public GameObject playerCam;
    public float screenShakeIntensity = 1f;
    int shakeCount = 0;
    public int shakes = 30;
    public GameObject player;
    public GameObject ring;
    Rigidbody rb;
    

	// Use this for initialization
	void Start () {
        rb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (shakeCount > 0)
        {
            ScreenShake();
            shakeCount--;
        }
        else
        {
            //playerCam.transform.localPosition = new Vector3();
            playerCam.transform.localPosition = Vector3.Lerp(playerCam.transform.localPosition, new Vector3(0,0,0), Time.deltaTime);
        }
	}

    //void OnTriggerEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "player_ring")
    //    {
    //        Debug.Log("oof");
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player_ring")
        {
            Debug.Log("oof");
            shakeCount = 30;

            ring.GetComponent<Ring>().turnSpeed = 0.0f;
            
        }
    }

    public void ScreenShake()
    {
        float shakeAmount = ((rb.velocity.magnitude / 30)) * screenShakeIntensity;
        if (Random.Range(-1,1) >= 0)
        {
            shakeAmount *= -1;
        }


        playerCam.transform.localPosition += new Vector3(shakeAmount, shakeAmount, shakeAmount);
    }
}
