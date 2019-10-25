using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Scenes;

// Flag indicating the end of the level
[RequireComponent(typeof(AudioSource))]
public class EndFlag : MonoBehaviour
{

	AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter2D (Collider2D trigger) {
		if (trigger.gameObject.tag == "Player") {
			// If the player enters the flagpole, trigger an event
			StartCoroutine(UseFlagpole());
		}
	}

	IEnumerator UseFlagpole() {

		// Play Sound Effects
		audioSource.Play();

		// TODO Play Animation
		// Wait for duration of animation
		yield return new WaitForSeconds(1.0f);
			
		GameController.Instance.NextLevel();
		
	}


}
