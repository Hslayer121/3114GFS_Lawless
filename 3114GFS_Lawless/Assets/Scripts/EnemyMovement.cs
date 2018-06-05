using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	private TurnBasedSystem turnSystem;
	private TurnClass turnClass;
	private bool isTurn = false;
	public float waitTime = 1f;

	List<GameObject> nodes = new List<GameObject>();			// A list of all the nodes in the scene

	public Transform[] movement = new Transform[4];				// This is the array of the transforms used for the enemy movement
	private Vector3 pos;										// This is used to move the enemy to a new position 
	public float speed = 2f;									// Speed at which the enemy moves between nodes

	private int turnstaken;
	public int nodeBlockage = 2;								// Number of turns to overcome a node block.
	private GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		turnSystem = GameObject.Find ("TurnSystem").GetComponent<TurnBasedSystem> ();
		gameObject.transform.parent.hasChanged = false;

		foreach (TurnClass tc in turnSystem.playersGroup) {
		if (tc.character.name == gameObject.name)
			turnClass = tc;
		}
		pos = gameObject.transform.position;	
	}

	void Update () {

		isTurn = turnClass.isTurn;

		if (isTurn) {
			StartCoroutine ("WaitAndMove");
		}
			
		if(gameObject.transform.parent != null){					//If the enemy has a parent
			if (gameObject.transform.parent.hasChanged) {			//And if that parent has changed position
			pos = gameObject.transform.parent.position;				//Change the position of the enemy to that position
			gameObject.transform.parent.hasChanged = false;			//And reset the position change check
			}
		}
			
		gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, pos, Time.deltaTime * speed);
	}

	IEnumerator WaitAndMove () {
		yield return new WaitForSeconds (waitTime);

		Movement (turnstaken);

		isTurn = false;
		turnClass.isTurn = isTurn;
		turnClass.wasTurnPrev = true;

		StopCoroutine ("WaitAndMove");
	}

	void Movement(int aLocation){
		if(!player.GetComponent<OverrideLevelAbility>().levelOverridden){
			if (movement [aLocation].GetComponent<Node> ().nodeBlocked && nodeBlockage > 0) {			// If the next node the enemy wants to move to is blocked and still has a turn timer...
				nodeBlockage--;																			// ...Remove one from the timer and return, ending the enemy's turn.
				return;
			} else if (movement [aLocation].GetComponent<Node> ().nodeBlocked && nodeBlockage == 0) {	// If the next node the enemy wants to move to is blocked, but has no more turn timer left...
				movement [aLocation].GetComponent<Node> ().nodeBlocked = false;							// Unblock the node.
				pos = movement [aLocation].transform.position;											// Allow the enemy to move to this position
				nodeBlockage = 2;																		// Reset the node block countdown
			} else if (movement [aLocation].GetComponent<Node> ().transform.position.y != gameObject.transform.position.y){
				return;
			} else {
				pos = movement [aLocation].transform.position;											// If the node isn't blocked at all, move.
				gameObject.transform.parent = null;														// Get rid of your current parent
				gameObject.transform.SetParent(movement [aLocation].transform);							// And change your parent to the node you are moving to 
			}
		} else {
			return;
		}


		turnstaken++;

		if (turnstaken > movement.Length - 1) {
			turnstaken = 0;
		}

		if(transform.position.y == movement [aLocation].transform.position.y){
			transform.LookAt (movement [aLocation].transform.position);								//Makes the enemy look toward the next node
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "NodeBlock"){
			Destroy (other.gameObject);
		}
	}
}
