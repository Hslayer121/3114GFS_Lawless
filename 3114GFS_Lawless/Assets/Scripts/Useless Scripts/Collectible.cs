using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

	private GameObject buttons;
	public GameObject overlay;
	private Camera cameraMain;
	private GameObject player;

	public GameObject information;
	public Transform triggerNode;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		buttons = GameObject.FindGameObjectWithTag ("Gameplay Buttons");
		//overlay = GameObject.FindGameObjectWithTag ("Information Overlay");
		cameraMain = Camera.main;

		overlay.SetActive (false);
		information.SetActive (false);
	}

	void Update () {
		RaycastHit hit;
		Ray ray = cameraMain.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out hit)) {
			if (Input.GetMouseButtonDown (0) && hit.collider.gameObject.tag == ("Information")) {
				if (player.transform.position == triggerNode.position) {
					buttons.SetActive (false);
					overlay.SetActive (true);
					information.SetActive (true);
				}
			}
		}
	}

	public void CloseOverlay (bool close) {
		if (close) {
			buttons.SetActive (true);
			overlay.SetActive (false);
			information.SetActive (false);
		}
	}
}
