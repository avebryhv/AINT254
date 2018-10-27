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
        RulesSelect();
    }

    public void TwoPlayer()
    {
        PlayerPrefs.SetInt("Players", 2);
        RulesSelect();
    }

    public void CircleArena()
    {
        SceneManager.LoadScene("CircleArena");
    }

    public void HoleArena()
    {
        SceneManager.LoadScene("HoleArena");
    }

    public void RulesSelect()
    {
        SceneManager.LoadScene("Rules Select");
    }
}
