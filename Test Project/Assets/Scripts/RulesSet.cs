using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RulesSet : MonoBehaviour {

    int timeLimit;
    string[] stageSelect;
    public Sprite[] backgroundImages;
    int selectedStage;
    public Text timeText;
    public Text stageText;
    public Text p2Text;
    public Image background;

	// Use this for initialization
	void Start () {
        timeLimit = 60;
        timeText.text = timeLimit.ToString();
        stageSelect = new string[] { "CircleArena", "LineArena", "FireArena"};
        selectedStage = 0;
        background.sprite = backgroundImages[selectedStage];
        stageText.text = stageSelect[selectedStage];
        PlayerPrefs.SetInt("Players", 1);
        p2Text.text = "CPU";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TimeIncrease()
    {
        if (timeLimit < 120)
        {
            timeLimit += 10;
            timeText.text = timeLimit.ToString();
        }
    }

    public void TimeDecrease()
    {
        if (timeLimit > 10)
        {
            timeLimit += -10;
            timeText.text = timeLimit.ToString();
        }
    }

    public void StageUp()
    {
        if (selectedStage < stageSelect.Length -1)
        {
            selectedStage += 1;
            stageText.text = stageSelect[selectedStage];
            background.sprite = backgroundImages[selectedStage];
        }
    }

    public void StageDown()
    {
        if (selectedStage > 0)
        {
            selectedStage += -1;
            stageText.text = stageSelect[selectedStage];
            background.sprite = backgroundImages[selectedStage];
        }
    }

    public void p2Human()
    {
        PlayerPrefs.SetInt("Players", 2);
        p2Text.text = "Human";
    }

    public void p2CPU()
    {
        PlayerPrefs.SetInt("Players", 1);
        p2Text.text = "CPU";
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("TimeLimit", timeLimit);
        SceneManager.LoadScene(stageSelect[selectedStage]);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
