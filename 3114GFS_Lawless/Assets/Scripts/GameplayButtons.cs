using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayButtons : MonoBehaviour {

	private HubExit hubExit;

	void Start () {
		hubExit = GameObject.Find ("ScreenFade").GetComponent <HubExit> ();
	}

	public void RestartGame (bool restart) {
		if (restart) {
			int sceneIndex = SceneManager.GetActiveScene ().buildIndex;			// Get name of current scene
			hubExit.FadeToLevel (sceneIndex);
		}
	}

	public void LeaveGame (bool leave) {
		if (leave) {
			hubExit.FadeToLevel (1);
		}
	}
}
