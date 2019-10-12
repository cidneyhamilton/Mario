using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{

	public bool isGrounded;

	void OnCollisionEnter2D(Collision2D col) {
		Debug.Log("Player has collided with " + col.collider.name);
		string tag = col.gameObject.tag;
		if (tag == "Ground" || tag == "Box" || tag == "LootBox") {
			isGrounded = true;
		}
	}
}
