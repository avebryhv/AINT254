using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject helpScreen;
    public GameObject creditsScreen;

	// Use this for initialization
	void Start () {
        helpScreen.SetActive(false);
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

    public void LineArena()
    {
        SceneManager.LoadScene("LineArena");
    }

    public void ShowHelp()
    {
        helpScreen.SetActive(true);
    }

    public void HideHelp()
    {
        helpScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        creditsScreen.SetActive(true);
    }

    public void HideCredits()
    {
        creditsScreen.SetActive(false);
    }


}
