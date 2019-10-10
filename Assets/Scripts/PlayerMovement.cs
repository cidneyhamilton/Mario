using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Character
{
	public int Speed = 10;
	public int JumpForce = 1250;
	public int BounceForce = 1000;

	private bool flipped = false;

	private GroundChecker GroundChecker;

	const float RAYCAST_HIT_DISTANCE = 0.9f;
	
	protected void Start() {
		base.Start();
		GroundChecker = GetComponent<GroundChecker>();
	}
	
	void FixedUpdate() {
		Move();
		Jump();
		PlayerRaycast();
	}

	void Move() {
		// controls
		float deltaX = Input.GetAxisRaw("Horizontal") * Speed;
		
		// animations

		// player direction
		if (deltaX < 0.0f && !flipped) {
			// Flip to the left
			Flip();
		} else if (deltaX > 0.0f && flipped) {
			Flip();
		}
		
		// Update the velocity
		rb.velocity = new Vector2(deltaX, rb.velocity.y);
		
	}

	void Jump() {
		if (Input.GetButtonDown("Jump") && GroundChecker.isGrounded) {
			rb.AddForce(Vector2.up * JumpForce);
			GroundChecker.isGrounded = false;
		}
	}

	void Flip() {
		flipped = !flipped;
		sr.flipX = flipped;
		
	}

	void PlayerRaycast() {

		RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
		if (rayUp != null && rayUp.collider != null && rayUp.distance < RAYCAST_HIT_DISTANCE) {
			if (rayUp.collider.tag == "LootBox") {
				// Destroy this box
				Destroy(rayUp.collider.gameObject);
			}
		}
		
		RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
		if (rayDown != null && rayDown.collider != null && rayDown.distance < RAYCAST_HIT_DISTANCE) {
			if (rayDown.collider.tag == "Enemy") {
				HitEnemy(rayDown.collider.gameObject);
			} 
		}
	}

	// Handles player jumping on the enemy
	void HitEnemy(GameObject enemy) {
		rb.AddForce(transform.up * BounceForce);
		enemy.GetComponent<EnemyMovement>().Die();	
	}
	
}
