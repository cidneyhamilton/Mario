using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Audio;

public class AudioController : MonoBehaviour
{

	void OnEnable() {
		
	}

	void OnDisable() {

	}

	// Play Sound Clip

	public static void PlayBreakBlock() {
		AudioEvents.PlaySound("smb_breakblock");
	}
	
	public static void PlayCollectCoin() {
		AudioEvents.PlaySound("smb_coin");
	}
	
	public static void PlayCollectPowerUp() {
		AudioEvents.PlaySound("smb_powerup");
	}

	public static void PlaySpawnPowerUp() {
		AudioEvents.PlaySound("smb_powerup_appears");
	}

	public static void PlayJump() {
		AudioEvents.PlaySound("smb_jumpsmall");
	}

	public static void PlayHitEnemy() {
		AudioEvents.PlaySound("smb_kick");
	}
	
	// Play Music Track
	
	public static void PlayLoop() {
		AudioEvents.PlayMusic("Super-Mario-Bros");
	}

	public static void PlayLose() {
		AudioEvents.PlayMusic("smb_mariodie");
	}
}
