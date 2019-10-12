using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Character
{
	public int Speed = 10;
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
			rb.AddForce(Vector2.up * JumpForce);
			GroundChecker.isGrounded = false;
		}
	}

	void Flip() {
		sr.flipX = !sr.flipX;		
	}

	void PlayerRaycast() {

		RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up, RAYCAST_HIT_DISTANCE);
		if (rayUp != null && rayUp.collider != null) {
			if (rayUp.collider.tag == "LootBox") {
				// Destroy this box
				Destroy(rayUp.collider.gameObject);
			}
		}
		
		RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
		if (rayDown != null && rayDown.collider != null) {
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
