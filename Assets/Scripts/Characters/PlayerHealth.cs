using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	int hitPoints = 1;
	const int maxHitPoints = 2;
	
	public void Die() {
		hitPoints--;

		if (hitPoints < 0) {
			// Death scene
			SceneController.Instance.GameOver();
		}
	}

	public void PowerUp() {
		if (hitPoints < maxHitPoints) {
			hitPoints++;

			IncreaseSize();
		}
	}

	void IncreaseSize() {
		// TODO: Animations
		// TODO: SFX
		transform.localScale += new Vector3(0.5f, 0.5f, 0);
	}

	void DecreaseSize() {
		// TODO: Animations
		// TODO: SFX
		transform.localScale -= new Vector3(0.5f, 0.5f, 0);
	}
	
	void Update() {
		// Check to see if the player has fallen down
		if (transform.position.y <  -5f) {
			hitPoints = 0;
			Die();
		}
	}

}
