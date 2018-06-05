using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoom : MonoBehaviour {
	public float Speed = 30f;											//Speed the room will rotate at

	void Update () {
		if(Input.GetKey(KeyCode.A)){									//When the A button is pressed...
			transform.Rotate (Vector3.up * Time.deltaTime *Speed);		//... Rotate the room to the left.
		}

		if(Input.GetKey(KeyCode.D)){									//When the D button is pressed...
			transform.Rotate (Vector3.down * Time.deltaTime *Speed);	//... Rotate the room to the right.
		}
	}
}
