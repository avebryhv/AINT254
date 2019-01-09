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

    void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        gameUI.enabled = false;
        pauseMenu.enabled = true;
    }

    void UnPause()
    {
        isPaused = false;
        Time.timeScale = 1;
        gameUI.enabled = true;
        pauseMenu.enabled = false;
    }
}
