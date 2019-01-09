using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour {

    AudioSource player;
    public AudioClip explosion;

	// Use this for initialization
	void Start () {
        player = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySound(AudioClip effect)
    {
        player.PlayOneShot(effect);
    }
}
