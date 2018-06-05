using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scramble : MonoBehaviour {

	private Camera cameraMain;
	private GameObject player;

	public LevelChange [] platforms;
	public Transform triggerNode;

	public GameObject smallCube;
	public GameObject medCube;
	public GameObject largeCube;

	private Animator animSmall;
	private Animator animMed;
	private Animator animLarge;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		cameraMain = Camera.main;
		animSmall = smallCube.GetComponent<Animator> ();
		animMed = medCube.GetComponent<Animator> ();
		animLarge = largeCube.GetComponent<Animator> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (player.transform.position == triggerNode.position) {
					player.transform.LookAt (transform.position);
					ScrambleLevel ();
				animSmall.SetTrigger ("Activate");
				animMed.SetTrigger ("Activate");
				animLarge.SetTrigger ("Activate");
			}
		}
	}

	void ScrambleLevel () {
		foreach (LevelChange p in platforms) {
			p.TogglePlatforms ();
		}
	}
}
