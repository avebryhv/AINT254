using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour {

    //Script used to play effects when both players collide

    public GameObject playerCam;
    public GameObject sparkEffect;
    public float screenShakeIntensity = 1f;
    int shakeCount = 0;
    public int shakes = 30;
    public GameObject player;
    public GameObject ring;
    AudioSource audioPlayer;
    public AudioClip hitSound;
    Rigidbody rb;
    

	// Use this for initialization
	void Start () {
        rb = player.GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (shakeCount > 0) //If the screen is supposed to be shaking (after collision), shakes screen
        {
            ScreenShake();
            shakeCount--;
        }
        else
        {
            
            //playerCam.transform.localPosition = new Vector3();
            playerCam.transform.localPosition = Vector3.Lerp(playerCam.transform.localPosition, new Vector3(0,0,0), Time.deltaTime); //Resets camera position
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
            shakeCount = 30; //Queues screen shakes
            audioPlayer.PlayOneShot(hitSound);
            Instantiate(sparkEffect, transform.position, transform.rotation); //Plays spark effect
            ring.GetComponent<Ring>().turnSpeed = 0.0f;
            
        }
    }

    public void ScreenShake()
    {
        float shakeAmount = ((rb.velocity.magnitude / 30)) * screenShakeIntensity;
        if (Random.Range(-1,1) >= 0) //Randomises direction of screen shake
        {
            shakeAmount *= -1;
        }


        playerCam.transform.localPosition += new Vector3(shakeAmount, shakeAmount, shakeAmount);
    }
}
