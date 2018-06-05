using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickNodeMovement : MonoBehaviour {
	
	private Vector3 pos;                       						// For player movement
	private float speed = 2.0f;										// Speed of movement
	public float waitDelay = 0.5f;									// Delay between the player movement and enemy movement turns

	public Transform[] nodes = new Transform[4];					// The array containing the nodes
	public GameObject[] nodeObjects = new GameObject[4];			// The array of all nodes as objects, to be used for raycasting.
	private ConnectingNodes currentNode;							// The current nodes the player can move to

	public Transform[] trailMemory = new Transform[3];

	private Camera cameraMain;										// The main camera used for raycasting
	public bool enemyTurn = false;									// Boolean to test if it is the enemy's turn to move, used by EnemyMovement for movement timing.
	public bool waiting = false;									// Boolean to test if player can move again.
	public bool overrideEnemy = false;								// Boolean to test if the enemy has been overridden , used by EnemyMovement for override mode 
	public bool playerMove = true;									// Tests if the player is allowed to move.

	public int overrideTurnCounter = 3;								// Counter for turns the enemy will wait once it has been overridden.


	void Start () {
		pos = transform.position;
	}

	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed); 		// This is what moves the player
		cameraMain = Camera.main;

		if (Input.GetKeyDown ("e")) {																	//If override button is pressed.
			foreach (GameObject node in nodeObjects) {													// For each of the nodes the player can move to...
				if (node.transform.position == GameObject.FindGameObjectWithTag("Enemy").transform.position) {			// ... If an enemy is on one of those nodes...
					overrideEnemy = true;																// The player will override them. Override is equal to true.
				}  else {
					playerMove = true;																	// If not, the player can make their movement as normal.
				}
			}
		}

		if (overrideEnemy) {											//If the enemy has been overridden
			if (overrideTurnCounter > 0) {								//If the turns left over is more than 0.
				if (!playerMove) {										// And if it is the enemy's turn to move.
					overrideTurnCounter -= 1;							// Take 1 off the turn countdown
					playerMove = true;									// And make it the player's turn to move.
					if (overrideTurnCounter <= 0) {						// If the countdown timer is 0.
						overrideEnemy = false;							// The enemy is no longer overridden
						overrideTurnCounter = 3;						// The timer resets itself for use.
					}
				}
			}
		}

		RaycastHit hit;															//Setting up Raycast
		Ray ray = cameraMain.ScreenPointToRay (Input.mousePosition);			// "			"

		if (Physics.Raycast (ray, out hit)) {									//Testing if raycast hits something
			if(Input.GetMouseButtonDown(0)){									//Testing if player presses the mouse
				if(!waiting){
					if (hit.transform.gameObject == nodeObjects [0]) {				//Testing if Raycast hits transform of the object set as Node 1
						pos = nodes [0].transform.position;							//Move player position to the position of Node 1
						playerMove = false;											//It is no longer the player's turn to move.
						waiting = true;												//The player must wait until the enemy has moved
						StartCoroutine(ExecuteAfterTime());							//Delay enemy movement
					} else if (hit.transform.gameObject == nodeObjects [1]) {		//Testing if Raycast hits transform of the object set as Node 2
						pos = nodes [1].transform.position;							//Move player position to the position of Node 2
						playerMove = false;											//It is no longer the player's turn to move.
						waiting = true;												//The player must wait until the enemy has moved
						StartCoroutine(ExecuteAfterTime());							//Delay enemy movement
					} else if (hit.transform.gameObject == nodeObjects [2]) {		//Testing if Raycast hits transform of the object set as Node 3
						pos = nodes [2].transform.position;							//Move player position to the position of Node 3
						playerMove = false;											//It is no longer the player's turn to move.
						waiting = true;												//The player must wait until the enemy has moved
						StartCoroutine(ExecuteAfterTime());							//Delay enemy movement
					} else if (hit.transform.gameObject == nodeObjects [3]) {		//Testing if Raycast hits transform of the object set as Node 4
						pos = nodes [3].transform.position;							//Move player position to the position of Node 4
						playerMove = false;											//It is no longer the player's turn to move.
						waiting = true;												//The player must wait until the enemy has moved
						StartCoroutine(ExecuteAfterTime());							//Delay enemy movement
					}
				}
			}
		}
	}

	void OnCollisionStay (Collision other) {
		
		currentNode = other.gameObject.GetComponent<ConnectingNodes>();		// Replacing the node transforms upon colliding with the new current node, used for player movement
		nodes [0] = currentNode.connectingPlayerNode [0].transform;
		nodes [1] = currentNode.connectingPlayerNode [1].transform;
		nodes [2] = currentNode.connectingPlayerNode [2].transform;
		nodes [3] = currentNode.connectingPlayerNode [3].transform;
		currentNode = other.gameObject.GetComponent<ConnectingNodes>();		// Replacing the node objects upon colliding with the new current node, used for raycasting
		nodeObjects [0] = currentNode.connectingPlayerNode [0];
		nodeObjects [1] = currentNode.connectingPlayerNode [1];
		nodeObjects [2] = currentNode.connectingPlayerNode [2];
		nodeObjects [3] = currentNode.connectingPlayerNode [3];

		trailMemory [0] = currentNode.transform;							// The new current node becomes the first trail memory.
	}

	void OnCollisionExit (Collision other){
		trailMemory [2] = trailMemory [1];									// The new second trail becomes the prvious first trail
		trailMemory [1] = trailMemory [0];									// And the new first trail becomes the previous player location
	}

	IEnumerator ExecuteAfterTime(){
		yield return new WaitForSecondsRealtime (waitDelay);				//Wait two seconds before changing the booleans and letting the enemy move
		enemyTurn = true;											//Set Movement to True so that enemies know to move.
	}
}