using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public int Speed = 10;
	public int JumpForce = 1250;

	private bool flipped = false;

	private Rigidbody2D rb;
	private SpriteRenderer sr;
	
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}
	
	void FixedUpdate() {
		Move();
		Jump();
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
		if (Input.GetButtonDown("Jump")) {
			rb.AddForce(Vector2.up * JumpForce);
		}
	}

	void Flip() {
		flipped = !flipped;

		sr.flipX = flipped;
		
	}
	
}
