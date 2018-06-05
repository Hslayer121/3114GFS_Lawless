using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {

	//public float speed = 2.0f;
	private float distance;										// Float used to check the distance between the first trail and a node
	List<GameObject> nodes = new List<GameObject>();						// A list of all the nodes in the scene
	private Animator anim;
	private GameObject player;

	void Start (){
		foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node")) {		// For each object in the scene tagged "Node"...
			nodes.Add (node);															// ...Add it to the list "nodes"
		}

		player = GameObject.FindGameObjectWithTag ("Player");
		gameObject.transform.position = player.transform.position;
	}

	void Update () {
		anim = gameObject.GetComponent<Animator> ();
		gameObject.transform.LookAt (player.transform.position);
		if(player.GetComponent<PlayerMovement>().trailIsFaded){
			gameObject.transform.position = player.GetComponent<PlayerMovement> ().trailMemory [1];
		}
		
		foreach (GameObject node in nodes) {														//For each of the nodes in the list made earlier...
			distance = Vector3.Distance (gameObject.transform.position, node.transform.position);	//...Check the distance between the player and the node.
			if (distance == 0) {															// If the trail is on that node change the boolean playerOccupied on the Node script to true, to indicate that the player is on this node.
				node.GetComponent<Node> ().firstTrailOccupied = true;
			} else {																				// Else change it to false, because the player is NOT on this node.
				node.GetComponent<Node> ().firstTrailOccupied = false;
			}
		}
	}
}
