using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour {

	private GameObject player;
	public Text timer;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		SetCountText ();
	}
	
	// Update is called once per frame
	void Update () {
		SetCountText ();
	}

	void SetCountText () {
		timer.text = "Time Remaining to Next Scan " + player.GetComponent<TurnTimer>().currentCountdownTimer.ToString ();
	}
}
