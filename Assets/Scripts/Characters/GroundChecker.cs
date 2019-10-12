using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{

	// Transform that checks to see if this is grounded
	public Transform IsGroundedChecker;
	
	// References the Ground layer to keep track of Ground objects
	public LayerMask GroundLayer;
	
	// Radius to check against
	const float GROUND_CHECK_RADIUS = 0.07f;
	
	public bool isGrounded {
		get {			
            if (IsGroundedChecker == null) {
                Debug.LogError("Platformer needs a transform to check on whether it's grounded.");
                return false;
            }
            
            // Return true if it exists, false otherwise
            return GetGroundOverlapCircle() != null;
		}
	}

	
	// Generate a collider to check and see if there's overlap between the player and the ground
	Collider2D GetGroundOverlapCircle() {
		return Physics2D.OverlapCircle(IsGroundedChecker.position, GROUND_CHECK_RADIUS, GroundLayer);
	}
   
}
