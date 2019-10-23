using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Character
{

	public int EnemySpeed = 1;

	public int xMoveDirection = -1;

	bool isDead = false;

	const float SPOT_DISTANCE = 5f;
	const float HIT_DISTANCE = 0.5f;

	const int DEATH_FORCE = 200;
	
    // Update is called once per frame
    void FixedUpdate()
    {
		if (IsPlayerVisible() && !isDead) {
			Chase();
			CheckCollision();
		} 
    }

	void Chase() {
		rb.velocity = new Vector2(xMoveDirection, 0) * EnemySpeed;
	}

	// TODO: Refactor to use spherical collider
	bool IsPlayerVisible() {
		RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector2.left, SPOT_DISTANCE);
		RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector2.right, SPOT_DISTANCE);
		
		return IsPlayer(leftHit) || IsPlayer(rightHit);
	}

	// Helper method to check to see if a hit is valid
	bool IsValid(RaycastHit2D hit) {
		return hit != null && hit.collider != null;
	}

	// Helper method to see if the player was hit
	bool IsPlayer(RaycastHit2D hit) {
		return IsValid(hit) && hit.collider.tag == "Player";
	}

	void CheckCollision() {

		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0), HIT_DISTANCE);
		
		if (IsPlayer(hit)) {
			// Kill Player
			hit.collider.GetComponent<PlayerHealth>().Die();
		}

		if (IsValid(hit) && hit.collider.tag != "Player") {
			// Change directions when hitting an obstacle
			Flip();
		}

	}

	void Flip() {
		if (xMoveDirection > 0) {
			xMoveDirection = -1;
		} else {
			xMoveDirection = 1;
		}

		sr.flipX = !sr.flipX;		
	}

	public void Die() {
		rb.AddForce(Vector2.right * DEATH_FORCE);
		rb.freezeRotation = false;
		rb.gravityScale = 8f;
		GetComponent<BoxCollider2D>().enabled = false;
		this.isDead = true;
	}
}
