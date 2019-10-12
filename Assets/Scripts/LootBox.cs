using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{

	public bool HasCoin;
	public bool HasPowerUp;

	private bool isShaking = false;

	Vector3 startPosition, endPosition;
	private float startTime;
	private float speed = 40f;
	private float duration = 0.25f;
	
	void Start() {
		startPosition = transform.position;
		
		endPosition = transform.position;
		endPosition.y += 0.75f;
	}
	
	void Update() {
		if (isShaking) {
			transform.position = new Vector3(transform.position.x, startPosition.y + Mathf.Sin(Time.time *  speed) * 0.1f, transform.position.z);
		}
	}
	
	// Triggered when the player hits her head on this box
    public void Hit() {
		isShaking = true;
		startTime = Time.time;
		StartCoroutine(DestroyOnHit());
		
	}

	IEnumerator DestroyOnHit() {
		yield return new WaitForSeconds(duration);
		Destroy(gameObject);
	}
}
