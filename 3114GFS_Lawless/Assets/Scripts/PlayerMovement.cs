using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	//For Movement
	private Vector3 pos;										// This is used to move the player to a new position 
	private float distance;										// Float used to check the distance between the player and a node
	public float speed = 2f;									// Speed at which the player moves between nodes
	List<GameObject> nodes = new List<GameObject>();			// A list of all the nodes in the scene

	//For Turns
	private TurnBasedSystem turnSystem;
	private TurnClass turnClass;
	public bool isTurn = false;

	//For Trail
	public Vector3[] trailMemory = new Vector3[2];
	public bool trailIsFaded = true;
	private Animator playerAnimator;
	private Animator trailAnimator;

	void Start (){
		trailMemory [0] = gameObject.transform.position;	//The trails become the player's position when starting the game.
		trailMemory [1] = gameObject.transform.position;

		foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node")) {		// For each object in the scene tagged "Node"...
			nodes.Add (node);															// ...Add it to the list "nodes"
		}

		turnSystem = GameObject.Find ("TurnSystem").GetComponent<TurnBasedSystem> ();

		foreach (TurnClass tc in turnSystem.playersGroup) {
			if (tc.character.name == gameObject.name)
				turnClass = tc;

			pos = gameObject.transform.position;											// Assigning pos a value. At the start of the game, pos = where the player is so the player does not move.

			playerAnimator = gameObject.GetComponent<Animator> ();
		}
	}

	void Update () {
		trailAnimator = GameObject.FindGameObjectWithTag("Trail").GetComponent<Animator>();

		gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, pos, Time.deltaTime * speed);	// This moves the player from its position to the new position when WASD is pressed.
		trailMemory [0] = pos;																								//The player's position for trail referencing																							
			
		isTurn = turnClass.isTurn;

		foreach (GameObject node in nodes) {														//For each of the nodes in the list made earlier...
			distance = Vector3.Distance (transform.position, node.transform.position);				//...Check the distance between the player and the node.
			if (distance == 0) {																	// If the player is on that node change the boolean playerOccupied on the Node script to true, to indicate that the player is on this node.
				node.GetComponent<Node> ().playerOccupied = true;
			} else {																				// Else change it to false, because the player is NOT on this node.
				node.GetComponent<Node> ().playerOccupied = false;
			}

			if (isTurn) {
				if (distance <= 2 && distance != 0) {																											// Tests if the node is within a radius of 2 from the player, and is not the node the player is currently on.
					if (Input.GetKeyDown (KeyCode.S)) {																											// If it is close enough and the player presses S.
						if (node.transform.position.x == gameObject.transform.position.x && node.transform.position.z <= gameObject.transform.position.z) {		// And it is directly south of the player (ie. if the node is the same x position, but has a larger z position)
							transform.LookAt (node.transform.position);
							pos = node.transform.position;																										// The player moves to its position because pos changes to the node's transform.
							node.GetComponent<Node> ().suspicionAdded = false;
							PlayerTrail();																														// Changes the player trail
							playerAnimator.SetBool("Movement", true);
							isTurn = false;
							turnClass.isTurn = isTurn;
							turnClass.wasTurnPrev = true;
						}
					} else if (Input.GetKeyDown (KeyCode.A)) {																									// If it is close enough and the player presses A.
						if (node.transform.position.x <= gameObject.transform.position.x && node.transform.position.z == gameObject.transform.position.z) {		// And it is directly west of the player (ie. if the node is the same z position, but has a lower x position)
							transform.LookAt (node.transform.position);
							pos = node.transform.position;																										// The player moves to its position because pos changes to the node's transform.
							PlayerTrail();																														// Changes the player trail
							playerAnimator.SetBool("Movement", true);
							isTurn = false;
							turnClass.isTurn = isTurn;
							turnClass.wasTurnPrev = true;
						}
					} else if (Input.GetKeyDown (KeyCode.W)) {																									// If it is close enough and the player presses W.
						if (node.transform.position.x == gameObject.transform.position.x && node.transform.position.z >= gameObject.transform.position.z) {		// And it is directly north of the player (ie. if the node is the same x position, but has a lower z position)
							transform.LookAt (node.transform.position);
							pos = node.transform.position;																										// The player moves to its position because pos changes to the node's transform.
							PlayerTrail();																														// Changes the player trail
							playerAnimator.SetBool("Movement", true);
							isTurn = false;
							turnClass.isTurn = isTurn;
							turnClass.wasTurnPrev = true;
						}
					} else if (Input.GetKeyDown (KeyCode.D)) {																									// If it is close enough and the player presses D.
						if (node.transform.position.x >= gameObject.transform.position.x && node.transform.position.z == gameObject.transform.position.z) {		// And it is directly east of the player (ie. if the node is the same x position, but has a larger x position)
							transform.LookAt (node.transform.position);
							playerAnimator.SetBool("Movement", true);
							pos = node.transform.position;																										// The player moves to its position because pos changes to the node's transform.
							PlayerTrail();																														// Changes the player trail
							isTurn = false;
							turnClass.isTurn = isTurn;
							turnClass.wasTurnPrev = true;
						}
					}
				}
			}
		}
	}

	void PlayerTrail(){
		trailMemory [1] = trailMemory [0];						//Trail 1 becomes the players last position
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Node"){
			playerAnimator.SetBool ("Movement", false);
		}
	}

	void OnCollisionStay(Collision other){
		if(trailIsFaded){
			StartCoroutine (FadeIn());
		}
	}
		
	void OnCollisionExit (Collision other){
		if (!trailIsFaded) {
			StartCoroutine (FadeOut());
		}
	}

	IEnumerator FadeOut(){
		trailAnimator.SetTrigger ("FadeOut");
		yield return new WaitForSeconds (0.5f);
		trailIsFaded = true;
	}

	IEnumerator FadeIn(){
		yield return new WaitForSeconds (0.25f);
		trailAnimator.SetTrigger ("FadeIn");
		trailIsFaded = false;
	}
}