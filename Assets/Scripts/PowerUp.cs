using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Platformer;

public class PowerUp : Character
{

	public float Speed = 2.8f;
	public int direction = 1;

	const float HIT_DISTANCE = 0.87f;

	private GroundChecker GroundChecker;

	bool landed;

	protected override void Start() {
		base.Start();
		GroundChecker = GetComponent<GroundChecker>();
	}
	
	void FixedUpdate() {
		CheckCollision();

		if (GroundChecker.IsGrounded) {

			Debug.Log("Adding force to powerup.");
			Vector2 newVelocity = rb.velocity;
			newVelocity.x = transform.right.x * Speed * direction;
			rb.velocity = newVelocity;
		} else {
			Debug.Log("We haven't landed.");
			landed = false;
		}
		
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

		if (!landed && GroundChecker.IsGrounded) {
			Debug.Log("Hitting the ground; changing direction.");
			landed = true;
			ChangeDirection();
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
