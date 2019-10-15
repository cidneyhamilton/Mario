using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Character
{
	public int Speed = 6;
	public int JumpForce = 1250;
	public int BounceForce = 1000;

	private GroundChecker GroundChecker;

	const float RAYCAST_HIT_DISTANCE = 0.87f;

	private Animator anim;
	
	protected void Start() {
		base.Start();
		GroundChecker = GetComponent<GroundChecker>();
		anim = GetComponent<Animator>();
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
		if (deltaX != 0 ) {
			anim.SetBool("isWalking", true);
		} else {
			anim.SetBool("isWalking", false);
		}

		anim.SetBool("isJumping", !GroundChecker.isGrounded);
		
		// player direction
		if (deltaX < 0.0f && !sr.flipX) {
			// Flip to the left
			Flip();
		} else if (deltaX > 0.0f && sr.flipX) {
			Flip();
		}
		
		// Update the velocity
		rb.velocity = new Vector2(deltaX, rb.velocity.y);
		
	}

	void Jump() {
		if (Input.GetButtonDown("Jump") && GroundChecker.isGrounded) {
			// Play Sound When Jumping
			AudioEvents.PlaySound("smb_jumpsmall");
			
			rb.AddForce(Vector2.up * JumpForce);
		}
	}

	void Flip() {
		sr.flipX = !sr.flipX;		
	}

	void PlayerRaycast() {

		RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up, RAYCAST_HIT_DISTANCE);
		if (rayUp != null && rayUp.collider != null) {
			if (rayUp.collider.tag == "LootBox") {
				rayUp.collider.gameObject.GetComponent<LootBox>().Hit();
				// Destroy this box
			} else if (rayUp.collider.tag == "PowerUp") {
				Debug.Log("Eating powerup.");
			   
				GetComponent<PlayerHealth>().PowerUp();

				Destroy(rayUp.collider.gameObject);
			} 
		}
		
		RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down, RAYCAST_HIT_DISTANCE);
		if (rayDown != null && rayDown.collider != null) {
			if (rayDown.collider.tag == "Enemy") {
				HitEnemy(rayDown.collider.gameObject);
			} else if (rayDown.collider.tag == "PowerUp") {
				Debug.Log("Eating powerup.");
			   
				GetComponent<PlayerHealth>().PowerUp();

				Destroy(rayDown.collider.gameObject);
			}
		}
	}

	// Handles player jumping on the enemy
	void HitEnemy(GameObject enemy) {

		// SFX
		AudioEvents.PlaySound("smb_kick");

		// Rebound Player
		rb.AddForce(transform.up * BounceForce);

		// Enemy death event
		enemy.GetComponent<EnemyMovement>().Die();	
	}
	
}
