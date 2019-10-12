using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{

	public bool HasCoin;
	public bool HasPowerUp;

	public Transform spawnPoint;
	public Coin coinPrefab;

	private bool hit = false;
	private bool isShaking = false;

	Vector3 startPosition, endPosition;
	private float startTime;
	private float speed = 40f;
	private float duration = 0.25f;
	
	void Start() {
		startPosition = transform.position;
	}
	
	void Update() {
		if (isShaking) {
			Shake();
		}
	}

	void Shake() {
		float deltaY = Mathf.Sin(Time.time * speed) * 0.1f;
		transform.position = new Vector3(startPosition.x, startPosition.y + deltaY, startPosition.z);
	}
	
	
	// Triggered when the player hits her head on this box
    public void Hit() {
		if (hit) {
			// Already triggered
		} else {
			// Make sure the payload only happens once
			hit = true;

			// Spawn Coin/Powerup
			CreateCoin();
			
			// Animate
			isShaking = true;
			startTime = Time.time;
			
			// Destroy
			StartCoroutine(DestroyOnHit());
		}
		
	}

	void CreateCoin() {
		Instantiate(coinPrefab, spawnPoint.position, transform.rotation);
	}

	IEnumerator DestroyOnHit() {
		yield return new WaitForSeconds(duration);
		Destroy(gameObject);
	}
}
