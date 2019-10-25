using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Cyborg.Scenes;

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
			GameController.Instance.Restart();
		}
    }
	
	void UpdateUI() {
		// Update UI
		timeLeftLabel.text = "Time Left: " + (int) timeLeft;
		
		playerScoreLabel.text = "Score: " + playerScore.ToString();
	
	}

	public void IncreaseScore(int amount) {
		playerScore += amount;
		UpdateUI();
	}

	
}
