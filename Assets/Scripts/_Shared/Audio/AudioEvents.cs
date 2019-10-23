﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cyborg.Audio {

	public class AudioEvents
	{
		
		// Play a sound effect clip
		public delegate void PlaySoundHandler(string soundClipName);
		public static event PlaySoundHandler OnPlaySound;
		public static event PlaySoundHandler OnPlayMusic;
		
		// Pause or unpause the background music
		public static event Action OnPause;
		public static event Action OnUnPause;
		
		// Handles playing a sound
		public static void PlaySound(string clipName) {
			if (OnPlaySound != null) {
				OnPlaySound(clipName);
			}	
		}

		// Handles changing the background music track
		public static void PlayMusic(string clipName) {
			if (OnPlayMusic != null) {
				OnPlayMusic(clipName);
			}
		}

		// Handles pausing and unpausing
		
		public static void Pause() {
			if (OnPause != null) {
				OnPause();
			}
		}
		
		public static void UnPause() {
			if (OnUnPause != null) {
				OnUnPause();
			}
		}
		
	}
	
}
