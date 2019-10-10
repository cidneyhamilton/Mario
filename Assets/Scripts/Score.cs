﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

	public float timeLeft = 300.0f;
	public int playerScore = 0;

	public Text timeLeftLabel;
	public Text playerScoreLabel;

    // Update is called once per frame
    void Update()
    {	
		timeLeft -= Time.deltaTime;

		UpdateUI();
		
		if (timeLeft <= 0.0f) {
			// Kill the player if they run out of time
			SceneController.SwitchScene("SampleScene");
		}
    }

	void OnTriggerEnter2D (Collider2D trigger) {
		Debug.Log("Reached the end of the level.");
		CountScore();
	}

	void CountScore() {
		playerScore += (int) timeLeft;
		Debug.Log("Player score is " + playerScore);
		UpdateUI();

		// SceneController.SwitchScene("SampleScene");
	}

	void UpdateUI() {
		// Update UI
		timeLeftLabel.text = "Time Left: " + (int) timeLeft;
		
		playerScoreLabel.text = "Score: " + playerScore.ToString();
	
	}

	
}