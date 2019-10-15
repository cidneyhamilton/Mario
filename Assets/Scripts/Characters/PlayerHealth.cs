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
			// TODO: Death Animation
			StartCoroutine(PlayerDeath());
		}
	}

	IEnumerator PlayerDeath() {

		AudioEvents.PlayMusic("smb_mariodie");

		// TODO: Animate
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

		GetComponent<Animator>().SetTrigger("Death");
		yield return new WaitForSeconds(2.0f);
		
		// Death scene
		SceneController.Instance.GameOver();

		AudioEvents.PlayMusic("Super-Mario-Bros");
		GetComponent<Animator>().ResetTrigger("Death");
		
	}
	
	public void PowerUp() {
		if (hitPoints < maxHitPoints) {
			hitPoints++;

			// Play Sound
			AudioEvents.PlaySound("smb_powerup");
			
			// Animate
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
