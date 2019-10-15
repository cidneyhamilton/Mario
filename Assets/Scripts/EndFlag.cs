using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Flag indicating the end of the level
public class EndFlag : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D trigger) {
		if (trigger.gameObject.tag == "Player") {

			StartCoroutine(UseFlagpole());
		}
	}

	IEnumerator UseFlagpole() {
		// Play Sound Effects
		AudioEvents.PlaySound("smb_flagpole");

		// TODO Play Animation

		yield return new WaitForSeconds(1.0f);
			
		// TODO: Advance to Next Level
		SceneController.Instance.GameOver();
		
	}

}
