using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

	protected Rigidbody2D rb;
	protected SpriteRenderer sr;
	
	protected void Start() {
		rb = gameObject.GetComponent<Rigidbody2D>();
		sr = gameObject.GetComponent<SpriteRenderer>();
	}
}
