using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public Canvas pauseMenu;
    public Canvas gameUI;
    bool isPaused = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            if (isPaused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
	}

    void Pause() //Pauses the game
    {
        isPaused = true;
        Time.timeScale = 0; //Prevents movement
        gameUI.enabled = false; //Toggles UI visibility
        pauseMenu.enabled = true; //Toggles menu visibility
    }

    void UnPause()
    {
        isPaused = false;
        Time.timeScale = 1; //Reenables movement
        gameUI.enabled = true; //Toggles UI visibility
        pauseMenu.enabled = false; //Toggles menu visibility
    }
}
