using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyMovement : MonoBehaviour {

	private TurnBasedSystem turnSystem;
	private TurnClass turnClass;
	private bool isTurn = false;
	public float waitTime = 1f;

	List<GameObject> nodes = new List<GameObject>();			// A list of all the nodes in the scene

	private Vector3 pos;										// This is used to move the player to a new position 
	private float distance;										// Float used to check the distance between the player and a node
	public float speed = 2f;									// Speed at which the player moves between nodes

	private GameObject player;

	// Use this for initialization
	void Start () {

		player = GameObject.Find ("Player");

		turnSystem = GameObject.Find ("TurnSystem").GetComponent<TurnBasedSystem> ();

		foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node")) {		// For each object in the scene tagged "Node"...
		nodes.Add (node);																// ...Add it to the list "nodes"
		}
			
		foreach (TurnClass tc in turnSystem.playersGroup) {
			if (tc.character.name == gameObject.name)
				turnClass = tc;
		}
		pos = gameObject.transform.position;	
	}
	
	// Update is called once per frame
	void Update () {

		isTurn = turnClass.isTurn;

		if (isTurn) {
			StartCoroutine ("WaitAndMove");
		}

		gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, pos, Time.deltaTime * speed);
	}

	IEnumerator WaitAndMove () {
		yield return new WaitForSeconds (waitTime);

		Movement ();

		isTurn = false;
		turnClass.isTurn = isTurn;
		turnClass.wasTurnPrev = true;

		StopCoroutine ("WaitAndMove");
	}

	void Movement () {

		foreach (GameObject node in nodes) {														//For each of the nodes in the list made earlier...
			distance = Vector3.Distance (transform.position, node.transform.position);				//...Check the distance between the player and the node.
			if (distance == 0) {																	// If the player is on that node change the boolean enemyOccupied on the Node script to true, to indicate that the player is on this node.
				node.GetComponent<Node> ().enemyOccupied = true;
			} else {																				// Else change it to false, because the player is NOT on this node.
				node.GetComponent<Node> ().enemyOccupied = false;
			}

		
		if (isTurn) {
				if (!player.GetComponent<OverrideLevelAbility> ().levelOverridden) {
					if (GameObject.Find ("SuspicionMeter").GetComponent<SuspicionMeter> ().currentSuspicion == 4) {
						if (distance <= 2 && distance != 0) {																											// Tests if the node is within a radius of 2 from the player, and is not the node the enemy is currently on.
							if (player.transform.position.z < gameObject.transform.position.z) {																		// If it is close enough and the player presses S.
								if (node.transform.position.x == gameObject.transform.position.x && node.transform.position.z <= gameObject.transform.position.z) {		// And it is directly south of the player (ie. if the node is the same x position, but has a larger z position)
									pos = node.transform.position;																										// The player moves to its position because pos changes to the node's transform.																												
									isTurn = false;
									turnClass.isTurn = isTurn;
									turnClass.wasTurnPrev = true;
								}
							} else if (player.transform.position.z > gameObject.transform.position.z) {																	// If it is close enough and the player presses W.
								if (node.transform.position.x == gameObject.transform.position.x && node.transform.position.z >= gameObject.transform.position.z) {		// And it is directly north of the player (ie. if the node is the same x position, but has a lower z position)
									pos = node.transform.position;							
									isTurn = false;
									turnClass.isTurn = isTurn;
									turnClass.wasTurnPrev = true;
								}
							} else if (player.transform.position.x < gameObject.transform.position.x) {																		// If it is close enough and the player presses A.
								if (node.transform.position.x <= gameObject.transform.position.x && node.transform.position.z == gameObject.transform.position.z) {		// And it is directly west of the player (ie. if the node is the same z position, but has a lower x position)
									pos = node.transform.position;																											// The player moves to its position because pos changes to the node's transform.																													// Changes the player trail
									isTurn = false;
									turnClass.isTurn = isTurn;
									turnClass.wasTurnPrev = true;
								}
							} else if (player.transform.position.x > gameObject.transform.position.x) {																	// If it is close enough and the player presses D.
								if (node.transform.position.x >= gameObject.transform.position.x && node.transform.position.z == gameObject.transform.position.z) {		// And it is directly east of the player (ie. if the node is the same x position, but has a larger x position)
									pos = node.transform.position;																									// The player moves to its position because pos changes to the node's transform.																													// Changes the player trail
								isTurn = false;
									turnClass.isTurn = isTurn;
									turnClass.wasTurnPrev = true;
								}
							}
						}
					}
				} else {
					isTurn = false;
					turnClass.isTurn = isTurn;
					turnClass.wasTurnPrev = true;
				}
			}
		}
	}
}

