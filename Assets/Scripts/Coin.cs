using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	// Number of score points gained from collecting this coin
	public int Points = 10;

	float startTime;
	Vector3 startPosition, endPosition;
	float speed = 30f;

	const float SHAKE_DURATION = 0.25f;
	
	void Start() {
		// Animate
		StartCoroutine(CollectAfterDelay());
		startTime = Time.time;

		startPosition = transform.position;
		endPosition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
	}

	void Update() {
		Shake();
	}

	void Shake() {
		float amount = (Time.time - startTime) * speed / 5f;
		transform.position = Vector3.Lerp(startPosition, endPosition, amount);
	}
	
	IEnumerator CollectAfterDelay() {
		yield return new WaitForSeconds(SHAKE_DURATION);
		CollectCoin();
	}
	
    void OnTriggerEnter2D(Collider2D trigger) {
		if (trigger.gameObject.tag == "Player") {
			CollectCoin();
		}
	}

	void CollectCoin() {

		AudioController.PlayCollectCoin();
		
		// Increase player score
		// TODO: use event system
		GameObject.FindObjectOfType<Score>().IncreaseScore(Points);
		
		// Destroy the coin
		Destroy(gameObject);
	}
}
