using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAnimator : MonoBehaviour
{
	protected bool hit = false;
	private bool isShaking = false;

	Vector3 startPosition, endPosition;
	private float startTime;
	private float speed = 40f;
	private float duration = 0.25f;
	
	// Empty box prefab
	public GameObject boxPrefab;
	
	void Start() {
		startPosition = transform.position;
	}
	
	void Update() {
		if (isShaking) {
			Shake();
		}
	}		
	
	// Triggered when the player hits her head on this box
    public virtual void Hit() {
		if (hit) {
			// Already triggered
		} else {
			// Make sure the payload only happens once
			hit = true;
		
			// Animate
			isShaking = true;
			startTime = Time.time;

			// Replace With Inert Box
			StartCoroutine(DestroyOnHit());

		}
		
	}

	protected void Shake() {
		float deltaY = Mathf.Sin(Time.time * speed) * 0.1f;
		transform.position = new Vector3(startPosition.x, startPosition.y + deltaY, startPosition.z);
	}	

	IEnumerator DestroyOnHit() {
		yield return new WaitForSeconds(duration);

		// Create a clone that isn't interactable
		Instantiate(boxPrefab, startPosition, transform.rotation);

		// Destroy this game object
		Destroy(gameObject);
	}
	
}
