using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverComputer : MonoBehaviour {

	public GameObject computer;

	//private Vector3 

	// Use this for initialization
	void Start () {
		computer.SetActive (false);
	}

	void OnMouseEnter () {
		computer.SetActive (true);
		}
	void OnMouseExit () {
		computer.SetActive (false);
	}
}
