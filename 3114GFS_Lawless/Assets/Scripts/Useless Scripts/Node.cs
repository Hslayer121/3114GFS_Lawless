/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	private Vector3 pos;                       				// For player movement
	private float speed = 2.0f;								// Speed of movement

	public Transform[] nodes = new Transform[4];			// The array containing the nodes (Order of nodes is w,a,s,d)
	private NewNode currentNode;							// The current nodes the player can move to
	//private EnemyNode enemyNode;

	private int gameState = 1;								// The gamestate of the world

	void Start () {
		pos = transform.position;
	}

	void Update () {

		// This bit is all temporary and allows us to change between state one and state two of the game world by pressing up and down
		if (Input.GetKey (KeyCode.UpArrow)) {
			gameState = 2;
			Debug.Log ("GameState TWO");
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			gameState = 1;
			Debug.Log ("GameState ONE");
		}

		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed); 		// This is what moves the player
		}

	void OnCollisionEnter (Collision other) {

		currentNode = other.gameObject.GetComponent<NewNode>();		// Replacing the nodes upon colliding with the new current node
		if (gameState == 1) {										// If the game is in state one
			nodes [0] = currentNode.newNodes1 [0];
			nodes [1] = currentNode.newNodes1 [1];
			nodes [2] = currentNode.newNodes1 [2];
			nodes [3] = currentNode.newNodes1 [3];
		} //else if (gameState == 2) {								// If the game is in state two
		//	nodes [0] = currentNode.newNodes2 [0];
		//	nodes [1] = currentNode.newNodes2 [1];
		//	nodes [2] = currentNode.newNodes2 [2];
		//	nodes [3] = currentNode.newNodes2 [3];
		//}
	}

	void OnCollisionStay (Collision other) {
		if (Input.GetKey (KeyCode.W)) {       	 		// Whatever node you want "W"
			pos = nodes [0].transform.position;
		} else if (Input.GetKey (KeyCode.A)) {        	// Whatever node you want "A"
			pos = nodes [1].transform.position;
		} else if (Input.GetKey (KeyCode.S)) {       	// Whatever node you want "S"
			pos = nodes [2].transform.position;
		} else if (Input.GetKey (KeyCode.D)) {       	// Whatever node you want "D"
			pos = nodes [3].transform.position;
		}
	}

	void OnCollisionExit (Collision other) {
		//enemyNode.Movement ();						// Player is not on a node
	}
}*/