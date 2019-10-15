using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : SoundController
{

	void OnEnable() {
		AudioEvents.OnPlayMusic += PlayMusic;
	}

	void OnDisable() {
		AudioEvents.OnPlayMusic -= PlayMusic;
	}

	public void PlayMusic(string clipName) {
		if (IsPlaying(clipName)) {
			// Do Nothing; already playing this clip
		} else {
			PlayClip(GetClipByName(clipName));
		}
	}
}


