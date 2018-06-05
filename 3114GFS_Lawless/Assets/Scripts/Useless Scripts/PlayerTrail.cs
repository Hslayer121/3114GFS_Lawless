using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrail : MonoBehaviour {

	private GameObject player;										// The player as an object
	private Transform[] trail = new Transform[2];					// Array of transforms for the last 2 positions the player has been to, based on the array in "ClickNodeMovement"
	public GameObject[] trailObjects = new GameObject[2];			// Array of GameObjects of the trail sprites/ghosts that will be seen in the gameplay.
	public float speed = 2.0f;										// Speed of movement

	private Vector3 posOne;
	private Vector3 posTwo;

	void Start () {
		player = GameObject.Find("Player");							// Referencing the player

		posOne = trail[0].transform.position;
		posTwo = trail[1].transform.position;
	}
	
	void Update () {

		trail[0].transform.position = Vector3.MoveTowards (gameObject.transform.position, posOne, Time.deltaTime * speed);
		trail[1].transform.position = Vector3.MoveTowards (gameObject.transform.position, posTwo, Time.deltaTime * speed);

		trail[0] = player.GetComponent<ClickNodeMovement> ().trailMemory [1].transform;			//Trail array reads the position of the previous place the player was from "ClickNodeMovement" and stores it in trail zero.
		trail[1] = player.GetComponent<ClickNodeMovement> ().trailMemory [2].transform;			//Trail array reads the position of the second previous place the player was from "ClickNodeMovement" and stores it in trail one.

		trailObjects[0].transform.position = Vector3.MoveTowards (trailObjects [0].transform.position, trail[0].position, Time.deltaTime * speed);		//The first trail object is moved from its current position towards the position the player was just in.
		trailObjects[1].transform.position = Vector3.MoveTowards (trailObjects [1].transform.position, trail[1].position, Time.deltaTime * speed);		//The second trail object is moved from its current position towards the position the first trail object was just in.
	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == ("Node")) {
			
		}
	}
}
