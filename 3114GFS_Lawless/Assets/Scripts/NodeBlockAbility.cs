using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBlockAbility : MonoBehaviour {

	private float distance;												// Float used to check the distance between the player and a node
	private List<GameObject> nodes = new List<GameObject>();			// A list of all the nodes in the scene

	public int remainingBlockUses = 0; 
	public GameObject nodeBlockage;


	void Start () {
		foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node")) {		// For each object in the scene tagged "Node"...
			nodes.Add (node);															// ...Add it to the list "nodes"
		}
	}

	void Update () {
		foreach (GameObject node in nodes) {														//For each of the nodes in the list made earlier...
			distance = Vector3.Distance (transform.position, node.transform.position);				//...Check the distance between the player and the node.
			if (distance == 0) {																	// If the player is on a node...
				if(Input.GetKeyDown(KeyCode.E) && remainingBlockUses > 0){							// And presses E and has node block abilities.
					node.GetComponent<Node> ().nodeBlocked = true;									// Set the node to blocked.
					remainingBlockUses--;															// And take away one of the usages
					Instantiate (nodeBlockage, node.transform);
				}
			}
		}
	}
}
