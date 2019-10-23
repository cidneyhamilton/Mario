using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles collisions between the player and their environment
public class PlayerCollisions : MonoBehaviour
{

	public int BounceForce = 1000;
	
	const float RAYCAST_HIT_DISTANCE = 0.87f;

	PlayerHealth health;

	void Start() {
		health = GetComponent<PlayerHealth>();
	}
	
	void FixedUpdate() {
		PlayerRaycast();
	}
	
	void PlayerRaycast() {

		Collider2D col;
				
		RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up, RAYCAST_HIT_DISTANCE);
		
		if (rayUp != null && rayUp.collider != null) {
			col = rayUp.collider;
			if (col.tag == "LootBox") {
				
				// Remove the loot from the box
			    col.gameObject.GetComponent<LootBox>().Hit();

			} else if (col.tag == "PowerUp") {
				Eat(col.gameObject.GetComponent<PowerUp>());
			} 
		}
		
		RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down, RAYCAST_HIT_DISTANCE);

		if (rayDown != null && rayDown.collider != null) {
			col = rayDown.collider;
			
			if (col.tag == "Enemy") {
				HitEnemy(col.gameObject);
			} else if (col.tag == "PowerUp") {
				Eat(col.gameObject.GetComponent<PowerUp>());
			}
		}
	}
	
	void Eat(PowerUp powerup) {
		// Debug.Log("Eating powerup.");

		// Consume the powerup
		health.PowerUp();

		// Destroy the powerup
		Destroy(powerup.gameObject);		
	}

	// Handles player jumping on the enemy
	void HitEnemy(GameObject enemy) {

		// SFX
		AudioController.PlayHitEnemy();

		// Rebound Player
		GetComponent<Rigidbody2D>().AddForce(transform.up * BounceForce);

		// Enemy death event
		enemy.GetComponent<EnemyMovement>().Die();	
	}
}
