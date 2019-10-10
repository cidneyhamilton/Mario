using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	
	public void Die() {
		SceneController.SwitchScene("SampleScene");
	}
	
	void Update() {
		// Check to see if the player has fallen down
		if (transform.position.y <  -5f) {
			Die();
		}
	}

}
