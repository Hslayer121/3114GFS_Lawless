using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementSentry : MonoBehaviour {

	private Vector3 posSentry;									// To change the enemies position
	private float speed = 2f;									// Speed at which the enemy moves between nodes
	public float waitDelay = 0.5f;								// Delay between the player movement and enemy movement turns
	private GameObject player;									// The player as an object
	public bool suspicionAdded = false;							// Boolean used to add suspicion at the correct time.
	public Transform[] nodesSentry = new Transform[1];				// The array containing the next node in the path/s the enemy can move to
	public GameObject[] nodesSentryObjects = new GameObject[1]; 	// The array containing the next object in the path/s the enemy will move to
	private ConnectingNodes currentSentryNode;						// The current nodes the enemy can move to

	void Start (){
		posSentry = gameObject.transform.position;
	}


	void Update(){
		gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, posSentry, Time.deltaTime * speed); 		// This is what moves the enemy
		player = GameObject.Find("Player");																							//Finds the player object

		if (player.GetComponent<ClickNodeMovement> ().enemyTurn) { 	
			posSentry = nodesSentry [0].transform.position;	
			if (IsPositionMatching ()) {	
				player.GetComponent<SuspicionMeter> ().currentSuspicion += 1;		//Add one to the suspicion level script on the player		
				suspicionAdded = true;												//Sets the boolean to true when suspicion has been added to the count.
			}
		StartCoroutine (ExecuteAfterTime ());								//Delay Player movement
		player.GetComponent<LevelEnemyList> ().enemyMovement += 1;			// The enemy ends it's turn
		suspicionAdded = false;	
		}
	}

	void OnCollisionEnter (Collision other) {
		currentSentryNode = other.gameObject.GetComponent<ConnectingNodes>();		// Replacing the nodes upon colliding with the new current node
		nodesSentry [0] = currentSentryNode.connectingSentryNode [0].transform;				
		nodesSentryObjects [0] = currentSentryNode.connectingSentryNode [0];
	}

		bool IsPositionMatching(){																	// Boolean to test if player's position is in the path or next movement of an enemy.
		foreach (GameObject node in nodesSentryObjects) {										// Checks each node/transform within the NewEnemyNodes1 array...
			if(player.transform.position == gameObject.transform.position){							// If the player position is the same as one of these next nodes
				if(!player.GetComponent<ClickNodeMovement>().enemyTurn){						// If the player has moved, and thus the enemy has moved to their next position.
					if(!suspicionAdded){														// If the suspicion has already been added, return false.
						return true;															// Returns boolean to true
						}
					}
				} 	
			}
			return false;																		// Else, it is set to false
		}

	IEnumerator ExecuteAfterTime(){
		yield return new WaitForSecondsRealtime (waitDelay);
		player.GetComponent<ClickNodeMovement> ().waiting = false;		// Sets the boolean for player waiting to false, thus allowing player movement
	}

}
	

