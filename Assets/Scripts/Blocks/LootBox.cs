using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Audio;

public class LootBox : BlockAnimator
{

	// TODO: Create a custom editor to set this up
	public bool HasPowerUp;

	public Transform spawnPoint;
	public Coin coinPrefab;
	public PowerUp mushroomPrefab;
	
	// Triggered when the player hits her head on this box
    public override void Hit() {
		if (hit) {
			// Already triggered
		} else {
			if (HasPowerUp) {
				CreateMushroom();
			} else {
				CreateCoin();
			}
		}
		base.Hit();		
	}

	void CreateCoin() {
		Instantiate(coinPrefab, spawnPoint.position, transform.rotation);
	}

	void CreateMushroom() {
		// Sound Effect
		AudioEvents.PlaySound("smb_powerup_appears");

		Instantiate(mushroomPrefab, spawnPoint.position, transform.rotation);
	}

}
