using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Text p1Score;
    public Text p2Score;
    public Text timeText;

    public GameObject player1;
    public GameObject player2;

    public float gameTime = 99;

    
	// Use this for initialization
	void Start () {
        gameTime = 99;
        p1Score.text = "0";
        p2Score.text = "0";
        timeText.text = gameTime.ToString();       


	}
	
	// Update is called once per frame
	void Update () {
        p1Score.text = player2.GetComponent<Player2>().score.ToString();
        p2Score.text = player1.GetComponent<Player>().score.ToString();

        gameTime -= Time.deltaTime;
        timeText.text = Mathf.Floor(gameTime).ToString();
    }
}
