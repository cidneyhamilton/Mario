using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	// Number of score points gained from collecting this coin
	public int Points = 10;
	
    void OnTriggerEnter2D(Collider2D trigger) {
		if (trigger.gameObject.tag == "Player") {
			CollectCoin();
		}
	}

	void CollectCoin() {
		// Increase player score
		// TODO: use event system
		GameObject.FindObjectOfType<Score>().IncreaseScore(Points);
		
		// Destroy the coin
		Destroy(gameObject);
	}
}
