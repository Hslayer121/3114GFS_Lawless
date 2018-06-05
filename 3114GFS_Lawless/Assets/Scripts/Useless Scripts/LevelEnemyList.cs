using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnemyList : MonoBehaviour {

	public int enemyMovement = 0;
	private GameObject player;									// The player as an object
	public int enemyAmount = 2;

	void Update () {
		player = GameObject.Find ("Player");																		//Finds the player object

		if (enemyMovement == enemyAmount) {
			player.GetComponent<ClickNodeMovement> ().enemyTurn = false;
			enemyMovement = 0;
		}

	}
}
