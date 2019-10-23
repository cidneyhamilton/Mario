using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : SoundController
{

	void OnEnable() {
		AudioEvents.OnPlayMusic += PlayMusic;
		AudioEvents.OnPause += Pause;
		AudioEvents.OnUnPause += UnPause;
	}

	void OnDisable() {
		AudioEvents.OnPlayMusic -= PlayMusic;
		AudioEvents.OnPause -= Pause;
		AudioEvents.OnUnPause -= UnPause;
	}

	public void PlayMusic(string clipName) {
		if (IsPlaying(clipName)) {
			// Do Nothing; already playing this clip
		} else {
			PlayClip(GetClipByName(clipName));
		}
	}

	public void Pause() {
		audioSource.Pause();
	}

	public void UnPause() {
		audioSource.UnPause();
	}
}


