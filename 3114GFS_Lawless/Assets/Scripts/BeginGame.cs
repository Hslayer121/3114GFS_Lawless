﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour {

	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			SceneManager.LoadScene ("MainMenu");
		}
	}
}
