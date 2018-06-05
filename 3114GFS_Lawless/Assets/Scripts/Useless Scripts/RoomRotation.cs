using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRotation : MonoBehaviour {

	private int position = 1;							// Used to set which location the camera is at or moving to. Default is middle position, position 1
	private Animator animator;							// The animator for the camera object

	void Start(){
		animator = GetComponent<Animator> ();			// Gets the animator from the object this script is on
	}

	void Update () {
		if (Input.GetKeyUp (KeyCode.A)) {				// Once the player presses the A key
			if (position > 0) {							// And the player is not at the left hand location
				position -= 1;							// Take one away from the location, thus moving the player to the left of their current camera position
				StartCoroutine(Wait());
			} else if (position <= 0){					// If it is at the left already, position 0.
				return;									// Stay at 0
			}
		}

		if (Input.GetKeyUp (KeyCode.D)) {				// Once the player presses the D key
			if (position < 3) {							// And the player is not at the right hand location
				position += 1;							// Add one to the location, thus moving the player to the right of their current camera position
				StartCoroutine(Wait());
			} else if (position >= 3){					// If the camera is at the right already, position 3
				return;									// Stay at 3
			}
		}

		if (position == 0) {							// If the location is moving to position 0...
			animator.SetInteger ("location", 0);		// ... Set the int in the animator to 0, thus allowing the animation movement
		} else if (position == 1) {						// If the location is moving to position 1...
			animator.SetInteger ("location", 1);		// ... Set the int in the animator to 1, thus allowing the animation movement
		} else if (position == 2) {						// If the location is moving to position 2...
			animator.SetInteger ("location", 2);		// ... Set the int in the animator to 2, thus allowing the animation movement
		}
	}

	public IEnumerator Wait(){
		yield return new WaitForSecondsRealtime(1f);
	}
}
