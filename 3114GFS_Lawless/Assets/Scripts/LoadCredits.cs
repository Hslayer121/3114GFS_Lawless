using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCredits : MonoBehaviour {

	private HubExit hubExit;

	void Start () {
		hubExit = GameObject.Find ("ScreenFade").GetComponent<HubExit> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			hubExit.FadeToLevel (4);
		}
	}
}
