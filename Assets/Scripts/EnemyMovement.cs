using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

	public int EnemySpeed;

	public int xMoveDirection;

	private Rigidbody2D rb;
	private SpriteRenderer sr;
	
	void Start() {
		rb = gameObject.GetComponent<Rigidbody2D>();
		sr = gameObject.GetComponent<SpriteRenderer>();
	}
	
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
