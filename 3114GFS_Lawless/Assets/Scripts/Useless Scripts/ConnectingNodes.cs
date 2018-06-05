using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingNodes : MonoBehaviour {

	public GameObject[] connectingEnemyNode = new GameObject[1]; 	// Put all ajacent nodes the enemy can move to

	public GameObject[] connectingSentryNode = new GameObject[1]; 	// Put all ajacent nodes the sentry can move to / look at.

	public GameObject[] connectingPlayerNode = new GameObject[4]; 	// Put all ajacent nodes the player can move to
}
