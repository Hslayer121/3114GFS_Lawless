using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

	private Camera cameraMain;

	public BoxCollider bed;
	public MeshCollider computer;
	public Transform canvas;
	public Transform quitMenu;

	void Start () {
		cameraMain = Camera.main;
	}

	void Update () {
		RaycastHit hit;
		Ray ray = cameraMain.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out hit)) {
			if (Input.GetMouseButtonDown (0) && hit.collider.gameObject.tag == ("Bed")) {
				Quit ();
			}
		}
	}

	public void Quit () {
		if (canvas.gameObject.activeInHierarchy == false)
		{
			if (quitMenu.gameObject.activeInHierarchy == false)
			{
				quitMenu.gameObject.SetActive (true);
			}
			canvas.gameObject.SetActive(true);
			bed.enabled = false;
			computer.enabled = false;
			Time.timeScale = 0;
		} else {
			canvas.gameObject.SetActive(false);
			bed.enabled = true;
			computer.enabled = true;
			Time.timeScale = 1;
		}
	}
		
	public void QuitGameMenu (bool Quit) {
		if (Quit) {
			Application.Quit();
			Debug.Log ("Quit Game");
		}
	}
}