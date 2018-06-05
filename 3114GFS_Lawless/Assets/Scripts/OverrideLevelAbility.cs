using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverrideLevelAbility : MonoBehaviour {

	private GameObject player;							//Gets the player as an object
	public int remainingOverrideUses = 1;				//The amount of uses the player has for this ability
	public int overrideTurns = 3;						//How many turns the player can take before the level stops being overridden
	public bool levelOverridden = false;				//Tests if the level is overridden. Used by the BigEnemyMovement, TurnTimer, EnemyMovement, Node scripts.
	private bool turnCount = false;						//Tests to make sure the turn count only reduces once per turn 

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");			//Sets the player automatically with the player tag
	}

	void Update () {
		if (remainingOverrideUses > 0) {					//If the player has override uses left
			if(Input.GetKeyDown(KeyCode.O)){				//And the player presses the O key
				if(!levelOverridden){						//If the level is not already overridden...
				levelOverridden = true;						//...Set it to overridden...
				overrideTurns = 3;							//...And set the turn counter to 3.
				}
			}
		}

		if(levelOverridden){											//Once the levelOverridden boolean is true which means the level is overridden,...
			if (!player.GetComponent<PlayerMovement> ().isTurn) {		//...When it is not the players turn on the movement script...
				if (overrideTurns > 0 && turnCount) {					//... and if the player has turns left, and a turn has not been taken away arleady...
					overrideTurns--;									//... Take away one turn.
					turnCount = false;									// And set turnCount to false, meaning it cannot take it away again.
				} else if (overrideTurns <= 0) {						// If the player runs out of overridden level turns...
					levelOverridden = false;							//... The level is no longer overridden.
				}
			} else if (player.GetComponent<PlayerMovement> ().isTurn){	//If it IS the player's turn...
				turnCount = true;										//... Reset the turn counter to take one away next time.
			}
		}
	}
}
