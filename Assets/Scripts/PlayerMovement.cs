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
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
		if (hit != null && hit.collider != null && hit.distance < RAYCAST_HIT_DISTANCE && hit.collider.tag == "Enemy") {
			Debug.Log("Squished enemy");

			rb.AddForce(transform.up * BounceForce);
			
			hit.collider.gameObject.GetComponent<EnemyMovement>().Die();

		}
	}
	
}
