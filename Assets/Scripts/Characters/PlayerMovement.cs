using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Platformer;

public class PlayerMovement : Character
{
	public int Speed = 6;
	public int JumpForce = 1250;

	private GroundChecker GroundChecker;
	
	protected override void Start() {
		base.Start();
		GroundChecker = GetComponent<GroundChecker>();
	}
	
	void FixedUpdate() {
		Move();
		Jump();
	}

	void Move() {
		// controls
		float deltaX = Input.GetAxisRaw("Horizontal") * Speed;
		
		// animations
		if (deltaX != 0 ) {
			animator.SetBool("isWalking", GroundChecker.IsGrounded);
		} else {
			animator.SetBool("isWalking", false);
		}

		animator.SetBool("isJumping", !GroundChecker.IsGrounded);
		
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
		if (Input.GetButtonDown("Jump") && GroundChecker.IsGrounded) {
			// Play Sound When Jumping
			AudioController.PlayJump();
			
			rb.AddForce(Vector2.up * JumpForce);
		}
	}

	void Flip() {
		sr.flipX = !sr.flipX;		
	}



	
}
