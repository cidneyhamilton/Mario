using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Flag indicating the end of the level
public class EndFlag : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D trigger) {
		if (trigger.gameObject.tag == "Player") {
			
			// TODO: Advance to Next Level
			SceneController.Instance.GameOver();
		}
	}

}
