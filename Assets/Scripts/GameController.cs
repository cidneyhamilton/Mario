using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Audio;
using Cyborg.Scenes;

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

	public void NextLevel() {
		SceneEvents.ChangeScene("SampleScene");
	}
	
	public void Restart() {
		StartCoroutine(GameOver());
	}

	IEnumerator GameOver() {		
		
		SceneEvents.ChangeScene("GameOver");

		yield return new WaitForSeconds(3.0f);
		
		AudioController.PlayLoop();	
		SceneEvents.ChangeScene("SampleScene");

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
