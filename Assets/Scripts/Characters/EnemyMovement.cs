using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Character
{

	public int EnemySpeed = 1;

	public int xMoveDirection = -1;

	bool isDead = false;

	const float HIT_DISTANCE = 0.5f;
	
    // Update is called once per frame
    void FixedUpdate()
    {
		if (isDead) {
			// Don't Move
		} else {
			Chase();
			CheckCollision();
		}
		
    }

	void Chase() {
		rb.velocity = new Vector2(xMoveDirection, 0) * EnemySpeed;
	}

	void CheckCollision() {

		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0));
		
		if (hit.distance < HIT_DISTANCE) {
			Flip();
			if (hit.collider.tag == "Player") {
				// Kill Player
				hit.collider.GetComponent<PlayerHealth>().Die();
			}
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
		rb.AddForce(Vector2.right * 200);
		rb.freezeRotation = false;
		rb.gravityScale = 8f;
		GetComponent<BoxCollider2D>().enabled = false;
		this.isDead = true;
	}
}
