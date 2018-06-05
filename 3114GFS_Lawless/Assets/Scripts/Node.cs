using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Node : MonoBehaviour {

	private GameObject player;
	public bool playerOccupied = false;						// The boolean that tests if the player is currently on this node.
	public bool enemyOccupied = false;						// The boolean that tests if an enemy is currently on this node.
	public bool firstTrailOccupied = false;					// If the first trail is on this node.
	public bool suspicionAdded = false;
	//private int playerOccupiedCounter = 0;
	private float distance;
	public bool nodeBlocked = false;

	private string sceneName;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		sceneName = SceneManager.GetActiveScene ().name;
	}

	void Update () {
		if(!player.GetComponent<OverrideLevelAbility>().levelOverridden){
			if (playerOccupied && enemyOccupied && !suspicionAdded) {
				GameObject.Find("SuspicionMeter").GetComponent<SuspicionMeter> ().currentSuspicion += 5f;
				suspicionAdded = true;
			}

			if (firstTrailOccupied && enemyOccupied && !suspicionAdded) {
				GameObject.Find("SuspicionMeter").GetComponent<SuspicionMeter> ().currentSuspicion += 1f;
				suspicionAdded = true;
			}
		}

		//distance = Vector3.Distance (transform.position, player.transform.position);
		//if(distance > 2){
		//	playerOccupiedCounter = 0;
		//}
	}

	void OnCollisionStay(Collision other){
		if (other.gameObject.tag == "Enemy") {
			enemyOccupied = true;
			if (playerOccupied == true) {
				SceneManager.LoadScene (sceneName);
			}
		} else {
			enemyOccupied = false;
		}
	}

	//void OnCollisionEnter(Collision other){
	//	if (other.gameObject.tag == "Player") {
	//		playerOccupiedCounter++;
	//		MovementCheck ();
	//	}
	//}

	//void MovementCheck(){
	//	if(playerOccupiedCounter > 3){
	//		GameObject.Find("SuspicionMeter").GetComponent<SuspicionMeter> ().currentSuspicion += 1f;			//Add one to the suspicion meter
	//	}
	//}
}
