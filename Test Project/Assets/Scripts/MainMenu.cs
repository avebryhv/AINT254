using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnePlayer()
    {
        PlayerPrefs.SetInt("Players", 1);
        SceneManager.LoadScene("CircleArena");
    }

    public void TwoPlayer()
    {
        PlayerPrefs.SetInt("Players", 2);
        SceneManager.LoadScene("CircleArena");
    }
}
