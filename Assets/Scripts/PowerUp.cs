using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Character
{

	public float Speed = 2.8f;
	public int direction = 1;

	const float HIT_DISTANCE = 0.87f;

	private GroundChecker GroundChecker;

	bool landed;

	protected void Start() {
		base.Start();
		GroundChecker = GetComponent<GroundChecker>();
	}
	
	void FixedUpdate() {
		if (GroundChecker.isGrounded) {
			Debug.Log("Adding force to powerup.");
			Vector2 newVelocity = rb.velocity;
			newVelocity.x = transform.right.x * Speed * direction;
			rb.velocity = newVelocity;
		} else {
			Debug.Log("We haven't landed.");
			landed = false;
		}
		CheckCollision();
		
	}

	void CheckCollision() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(direction, 0), HIT_DISTANCE);

		if (hit != null & hit.collider != null) {
			if (hit.collider.tag == "Player") {
				// Player consumes powerup
				HitPlayer();
			} else {
				Debug.Log("Collided with something.");
				ChangeDirection();
			}
		}

		RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down, HIT_DISTANCE);
		
		if (rayDown != null && rayDown.collider != null && !landed) {
			Debug.Log("Hitting the ground; changing direction.");
			ChangeDirection();
			landed = true;
		}

	}

	void ChangeDirection() {	
		direction = direction * -1;
		sr.flipX = !sr.flipX;
	}

	void HitPlayer() {
		Debug.Log("Eating powerup.");
		
		// Activate powerup
		// TODO: Use event
		GameObject.FindObjectOfType<PlayerHealth>().PowerUp();
		
		Destroy(this.gameObject);
	}

}
