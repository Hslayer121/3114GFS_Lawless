using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTimer : MonoBehaviour {

	private GameObject player;								//The player as a game object
	public int currentCountdownTimer;					//Current time for the countdown as a float
	public int countdown = 10;							//The amount of time wanted to be counted down from, can be updated like "countdown = 5"
	private bool countdownBegun = false;					//Boolean to test if the countdown has began

	private GameObject scanner;
	private Vector3 scannerStartPosition;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");		//Gets the player object
		scanner = GameObject.Find("ScannerBar");
		scannerStartPosition = scanner.transform.position;
		scanner.SetActive (false);
	}

	void Update () { 
		if(!player.GetComponent<OverrideLevelAbility>().levelOverridden){
			if (player.GetComponent<PlayerMovement>  ().isTurn && !countdownBegun) {		//Checks if it is the player's turn, and if the countdown has begun already.
			countdownBegun = true;														//If it is, and isn't respectively, begin the countdown.
			StartCoroutine(Countdown ());												//Calls the countdown function.
			}
		}

		if(scanner.activeInHierarchy){
			if (countdown == 10) {
				scanner.transform.Translate (Vector3.right * 3f * Time.deltaTime);
			} else if (countdown == 5) {
				scanner.transform.Translate (Vector3.right * 6f * Time.deltaTime);
			}
		}
	}

	public IEnumerator Countdown(){
		currentCountdownTimer = countdown;		//Sets the current countdown timer to the time wanted to be counted down from. This resets the countdown

		while (currentCountdownTimer > 0 && player.GetComponent<PlayerMovement> ().isTurn){		//When the time is bigger than 0, and it's still the players turn
			yield return new WaitForSecondsRealtime(1f);										//Wait 1 second then take 1 away from the countdown.
			currentCountdownTimer--;
		}

		if (currentCountdownTimer <= 0) {																						//When the countdown hits 0...
			scanner.SetActive(true);
			scanner.transform.position = scannerStartPosition;
			GameObject.Find("SuspicionMeter").GetComponent<SuspicionMeter> ().currentSuspicion += 1f;			//Add one to the suspicion meter
		} 

		countdownBegun = false;																								//Set the countdown as false, allowing it to start again.
	}		
}
