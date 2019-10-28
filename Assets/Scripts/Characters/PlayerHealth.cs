using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Audio;
using Cyborg.Platformer;
using Cyborg.Scenes;

public class PlayerHealth : Character
{

	bool invincible = false;
	
	int hitPoints = 1;
	const int maxHitPoints = 2;
	
	public void Die() {
		if (invincible) {
			// Do nothing; player is invincible
		} else if (hitPoints == maxHitPoints) {
			StartCoroutine(TakeDamage());
		} else {
			StartCoroutine(PlayerDeath());
		}
	}

	IEnumerator TakeDamage() {

		hitPoints--;

		AudioController.PlayPowerDown();

		// TODO: Animate
		
		DecreaseSize();	   
		
		invincible = true;

		yield return new WaitForSeconds(1.0f);

		invincible = false;
	}

	void PlayDeadAnimation() {
		rb.gravityScale = 1.0f;
		rb.AddForce(Vector2.up * 250.0f);
	}
	
	IEnumerator PlayerDeath() {
		AudioController.PlayLose();

		GetComponent<PlayerMovement>().enabled = false;

		rb.velocity = Vector2.zero;
		
		gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
		collider.isTrigger = true;
		
		animator.SetTrigger("Death");

		PlayDeadAnimation();
		
		yield return new WaitForSeconds(2.0f);
		
		// Death scene
		GameController.Instance.Restart();	   
		
		animator.ResetTrigger("Death");
		
	}
	
	public void PowerUp() {
		if (hitPoints < maxHitPoints) {
			hitPoints++;

			rb.velocity = Vector2.zero;
			
			// Play Sound
			AudioController.PlayCollectPowerUp();
			
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
