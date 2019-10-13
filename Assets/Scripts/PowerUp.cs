using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Character
{

	public int Force = 4;
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
			rb.AddForce(new Vector2(direction, 0) * Force);
		} else {
			landed = false;
		}
		CheckCollision();
		
	}

	void CheckCollision() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(direction, 0));

		if (hit != null & hit.collider != null && hit.distance < HIT_DISTANCE) {
			if (hit.collider.tag == "Player") {
				// Player consumes powerup
				HitPlayer();
			}
		}

		RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down, HIT_DISTANCE);
		
		if (rayDown != null && rayDown.collider != null && !landed) {
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
