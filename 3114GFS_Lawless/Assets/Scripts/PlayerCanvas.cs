using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanvas : MonoBehaviour {

	public GameObject canvas;
	public GameObject[] points = new GameObject[2];
	private GameObject player;

	// Use this for initialization
	void Start () {
		canvas.SetActive (false);
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		IsPositionMatching ();
	}

	void IsPositionMatching () {
		canvas.SetActive (false);

		foreach (GameObject p in points) {
			if (player.transform.position == p.transform.position) {
				canvas.SetActive (true);
			}
		}
	}
}
