﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioEvents
{

	// Play a sound effect clip
	public delegate void PlaySoundHandler(string soundClipName);
	public static event PlaySoundHandler OnPlaySound;
	public static event PlaySoundHandler OnPlayMusic;

	// Handles playing a sound
	public static void PlaySound(string clipName) {
		if (OnPlaySound != null) {
			OnPlaySound(clipName);
		}	
	}

	public static void PlayMusic(string clipName) {
		if (OnPlayMusic != null) {
			OnPlayMusic(clipName);
		}
	}


}