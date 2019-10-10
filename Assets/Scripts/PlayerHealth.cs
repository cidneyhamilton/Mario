using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	bool hasDied = false;
	
	void Update() {
		// Check to see if the player has fallen down
		if (!hasDied && transform.position.y <  -5f) {
			hasDied = true;
			StartCoroutine(Die());
		}
	}

	IEnumerator Die() {
		Debug.Log("Player has fallen.");

		hasDied = true;
		yield return new WaitForSeconds(1f);

		Debug.Log("Player has died.");
		SceneController.SwitchScene("SampleScene");
	}

}
