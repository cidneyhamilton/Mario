using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Character
{

	public int EnemySpeed;

	public int xMoveDirection;
	
    // Update is called once per frame
    void Update()
    {
		Chase();
    }

	void Chase() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0));

		rb.velocity = new Vector2(xMoveDirection, 0) * EnemySpeed;
		
		if (hit.distance < 0.7f) {
			Flip();
			if (hit.collider.tag == "Player") {
				// Kill Player
				Destroy(hit.collider.gameObject);
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
}
