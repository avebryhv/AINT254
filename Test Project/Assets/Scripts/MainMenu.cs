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

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnePlayer()
    {
        PlayerPrefs.SetInt("Players", 1);
        CircleArena();
    }

    public void TwoPlayer()
    {
        PlayerPrefs.SetInt("Players", 2);
        CircleArena();
    }

    public void CircleArena()
    {
        SceneManager.LoadScene("CircleArena");
    }
}
