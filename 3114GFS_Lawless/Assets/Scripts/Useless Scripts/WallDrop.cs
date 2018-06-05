using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDrop : MonoBehaviour {

	public GameObject[] walls = new GameObject[4];					//Array of the 4 walls of the room.

	private float side1 = 45;										//The angle at which the camera is facing the first wall/side
	private float side2 = 135;										//The angle at which the camera is facing the second wall/side
	private float side3 = 225;										//The angle at which the camera is facing the third wall/side
	private float side4 = 315;										//The angle at which the camera is facing the fourth wall/side
	private float currentPosition = 0f;								//The current position the camera is looking


	void Update () {
		currentPosition = transform.eulerAngles.y;					//The current position of the camera updates as it moves.
		if(currentPosition <= side1){								//If the camera is between the first view of the side, and the fourth side
			walls[0].SetActive (true);								//Set the two walls closest to the camera to false and the other two to true.
			walls[1].SetActive (true);								//This repeats for all variations of sides/angles
			walls[2].SetActive (false);
			walls[3].SetActive (false);
		} else if (currentPosition >=side4){
			walls[0].SetActive (true);
			walls[1].SetActive (true);
			walls[2].SetActive (false);
			walls[3].SetActive (false);
		}

		if(currentPosition >= side1 && currentPosition <= side2){
			walls[0].SetActive (false);
			walls[1].SetActive (true);
			walls[2].SetActive (true);
			walls[3].SetActive (false);
		}

		if(currentPosition >= side2 && currentPosition <= side3){
			walls[0].SetActive (false);
			walls[1].SetActive (false);
			walls[2].SetActive (true);
			walls[3].SetActive (true);
		}

		if(currentPosition <= side4 && currentPosition >= side3){
			walls[0].SetActive (true);
			walls[1].SetActive (false);
			walls[2].SetActive (false);
			walls[3].SetActive (true);
		}
	}
}
