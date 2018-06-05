using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementPathed : MonoBehaviour {

	private Vector3 posEnemy;									// To change the enemies position
	private float speed = 2f;									// Speed at which the enemy moves between nodes
	public float waitDelay = 0.5f;								// Delay between the player movement and enemy movement turns

	private Vector3 playerPosition; 							// Position of the player
	private GameObject player;									// The player as an object

	public Transform[] nodesEnemy = new Transform[1];			// The array containing the next node in the path/s the enemy can move to
	public GameObject[] nodesEnemyObjects = new GameObject[1]; 	// The array containing the next object in the path/s the enemy will move to
	private ConnectingNodes currentEnemyNode;					// The current nodes the enemy can move to
	private bool suspicionAdded = false;						// Boolean used to add suspicion at the correct time.

	void Start () {
		posEnemy = gameObject.transform.position;	
	}

	void Update () {
		
		gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, posEnemy, Time.deltaTime * speed); 		// This is what moves the enemy
		player = GameObject.Find("Player");																		//Finds the player object

		if (IsPositionMatching ()) {												//If the boolean is true and the player's position matches the next position of an enemy
			if (player.GetComponent<ClickNodeMovement> ().overrideEnemy) {			//If the enemy is overridden, do not add suspicion
				return;
			} else {																//Otherwise if the enemy is not overridden...
				player.GetComponent<SuspicionMeter>().currentSuspicion += 1;		//Add one to the suspicion level script on the player		
				suspicionAdded = true;												//Sets the boolean to true when suspicion has been added to the count.
			}
		}

		if(player.transform.position == posEnemy){								// If the player and the enemy are at the same position
			if(!suspicionAdded){												// And suspicion hasn't been added arleady
				if (!player.GetComponent<ClickNodeMovement> ().overrideEnemy) {
					player.GetComponent<SuspicionMeter> ().currentSuspicion += 2;		// Add suspicion
					suspicionAdded = true;												// And make sure no more suspicion can be added this turn
				} else {
					return;
				}
			}
		}

		if(player.GetComponent<ClickNodeMovement>().enemyTurn){ 								// If the boolean on script ClickNodeMovement is true, ie. the player moves
			if(!player.GetComponent<ClickNodeMovement>().overrideEnemy){						// Tests if the enemy is overridden by the player
				posEnemy = nodesEnemy [0].transform.position;									// If false, the enemy moves to its new position
			} 
			StartCoroutine(ExecuteAfterTime());													//Delay Player movement
			player.GetComponent<ClickNodeMovement> ().waiting = false;							// Sets the boolean for player waiting to false, thus allowing player movement
			player.GetComponent<LevelEnemyList> ().enemyMovement += 1;
			suspicionAdded = false;																// Enemy has moved, so suspicion can be added.
		}
	}

	void OnCollisionEnter (Collision other) {
		currentEnemyNode = other.gameObject.GetComponent<ConnectingNodes>();		// Replacing the nodes upon colliding with the new current node
		nodesEnemy [0] = currentEnemyNode.connectingEnemyNode [0].transform;				
		nodesEnemyObjects [0] = currentEnemyNode.connectingEnemyNode [0];
	}

	IEnumerator ExecuteAfterTime(){
		yield return new WaitForSecondsRealtime (waitDelay);
	}

	bool IsPositionMatching(){																	// Boolean to test if player's position is in the path or next movement of an enemy.
		foreach (GameObject node in nodesEnemyObjects) {										// Checks each node/transform within the NewEnemyNodes1 array...
			if(player.transform.position == node.transform.position){							// If the player position is the same as one of these next nodes
				if(!player.GetComponent<ClickNodeMovement>().enemyTurn){						// If the player has moved, and thus the enemy has moved to their next position.
					if(!suspicionAdded){														// If the suspicion has already been added, return false.
						return true;															// Returns boolean to true
					}
				}
			} 	
		}
		return false;																		// Else, it is set to false
	}
}
