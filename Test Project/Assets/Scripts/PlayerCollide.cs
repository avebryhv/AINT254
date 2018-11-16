using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour {

    public GameObject playerCam;
    public float screenShakeIntensity = 1f;
    int shakeCount = 0;
    public int shakes = 30;
    public GameObject player;
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
            playerCam.transform.localPosition = new Vector3();
            //Vector3.Lerp(playerCam.transform.localPosition, new Vector3(0,0,0), Time.deltaTime);
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
            if (rb.velocity.magnitude > 30)
            {
                shakeCount = 30;
            }
            else
            {
                shakeCount = Mathf.FloorToInt(rb.velocity.magnitude);
            }
            
            
        }
    }

    public void ScreenShake()
    {
        float shakeX = Random.Range(-screenShakeIntensity, screenShakeIntensity);
        float shakeY = Random.Range(-screenShakeIntensity, screenShakeIntensity);
        float shakeZ = Random.Range(-screenShakeIntensity, screenShakeIntensity);

        playerCam.transform.localPosition += new Vector3(shakeX, shakeY, shakeZ);
    }
}
