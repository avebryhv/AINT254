using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    public Text p1Score;
    public Text p2Score;
    public Text timeText;

    public GameObject player1;
    public GameObject player2;

    public float startTime = 99;
    float gameTime;

    public Text finalResult;
    public Canvas gameEnd;

    
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        gameTime = PlayerPrefs.GetInt("TimeLimit");
        p1Score.text = "0";
        p2Score.text = "0";
        timeText.text = gameTime.ToString();
        gameEnd.enabled = false;


    }

    // Update is called once per frame
    void Update () {
        p1Score.text = player2.GetComponent<Player2>().score.ToString();
        p2Score.text = player1.GetComponent<Player>().score.ToString();

        gameTime -= Time.deltaTime;
        

        if (gameTime <= 0)
        {
            

            if (player1.GetComponent<Player>().score == player2.GetComponent<Player2>().score)
            {
                timeText.text = "Sudden Death";
            }
            else
            {
                Time.timeScale = 0;
                gameEnd.enabled = true;
                GetComponent<Canvas>().enabled = false;
                if (player1.GetComponent<Player>().score < player2.GetComponent<Player2>().score)
                {
                    finalResult.text = "-Player 1 Wins-";
                }
                else
                {
                    finalResult.text = "-Player 2 Wins-";
                }

            }
        }
        else
        {
            timeText.text = Mathf.Floor(gameTime).ToString();
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
