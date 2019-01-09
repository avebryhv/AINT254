using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RulesSet : MonoBehaviour {

    int timeLimit;
    string[] stageSelect;
    string[] p2ModeText;
    public Sprite[] backgroundImages;
    int selectedStage;
    int p2Mode;
    public Text timeText;
    public Text stageText;
    public Text p2Text;
    public Image background;
    AudioSource Audioplayer;
    public AudioClip noise;

	// Use this for initialization
	void Start () {
        timeLimit = 60;
        timeText.text = timeLimit.ToString();
        stageSelect = new string[] { "CircleArena", "LineArena", "FireArena", "SnowArena"};
        p2ModeText = new string[] { "Human", "CPU (Easy)", "CPU (Hard)" };
        selectedStage = 0;
        p2Mode = 0;
        background.sprite = backgroundImages[selectedStage];
        stageText.text = stageSelect[selectedStage];
        PlayerPrefs.SetInt("Players", 1);
        p2Text.text = p2ModeText[p2Mode];
        Audioplayer = GetComponent<AudioSource>();
        
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
            Audioplayer.PlayOneShot(noise);
        }
    }

    public void TimeDecrease()
    {
        if (timeLimit > 0)
        {
            timeLimit += -10;
            timeText.text = timeLimit.ToString();
            Audioplayer.PlayOneShot(noise);
        }
    }

    public void StageUp()
    {
        if (selectedStage < stageSelect.Length -1)
        {
            selectedStage += 1;
            stageText.text = stageSelect[selectedStage];
            background.sprite = backgroundImages[selectedStage];
            Audioplayer.PlayOneShot(noise);
        }
    }

    public void StageDown()
    {
        if (selectedStage > 0)
        {
            selectedStage += -1;
            stageText.text = stageSelect[selectedStage];
            background.sprite = backgroundImages[selectedStage];
            Audioplayer.PlayOneShot(noise);
        }
    }

    public void p2Up()
    {
        if (p2Mode < p2ModeText.Length - 1)
        {
            p2Mode += 1;
            p2Text.text = p2ModeText[p2Mode];
            Audioplayer.PlayOneShot(noise);
        }
        //PlayerPrefs.SetInt("Players", 2);
        //p2Text.text = "Human";
    }

    public void p2Down()
    {
        if (p2Mode > 0)
        {
            p2Mode -= 1;
            p2Text.text = p2ModeText[p2Mode];
            Audioplayer.PlayOneShot(noise);
        }
        //PlayerPrefs.SetInt("Players", 1);
        //p2Text.text = "CPU";
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("TimeLimit", timeLimit);
        PlayerPrefs.SetInt("p2Mode", p2Mode);
        SceneManager.LoadScene(stageSelect[selectedStage]);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
