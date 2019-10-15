using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
	
	public void Pause() {
		AudioEvents.PlaySound("smb_pause");
		AudioEvents.Pause();

		Time.timeScale = 0.0f;
	}

	public void Unpause() {
		AudioEvents.UnPause();
		
		Time.timeScale = 1.0f;
	}

	void TogglePause() {
		if (Time.timeScale == 0.0f) {
			Unpause();
		} else {
			Pause();
		}
	}
	
	void Update() {
		if (Input.GetKeyUp(KeyCode.P)) {
			TogglePause();
		}
	}
}
