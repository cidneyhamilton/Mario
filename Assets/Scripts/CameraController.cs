using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private GameObject player;

	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;

	void Start() {
		player = GameObject.FindWithTag("Player");
	}

	void LateUpdate() {
		TrackPlayer();
	}

	void TrackPlayer() {
		float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
		float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);

		transform.position = new Vector3(x, y, transform.position.z);
	}
	
}
