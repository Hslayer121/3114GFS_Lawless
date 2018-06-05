using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitTerminal : MonoBehaviour {

	private GameObject player;
	public Transform triggerNode;

	private HubExit hubExit;
	private Animator playerAnimator;

	public GameObject right;
	public GameObject left;

	private Animator leftAnim;
	private Animator rightAnim;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		hubExit = GameObject.Find ("ScreenFade").GetComponent <HubExit> (); 

		rightAnim = right.GetComponent<Animator> ();
		leftAnim = left.GetComponent<Animator> ();
	}

	void Update () {
		playerAnimator = player.GetComponent<Animator>();
		if (Input.GetKey (KeyCode.Q)) {
			if (player.transform.position == triggerNode.position) {
			player.transform.LookAt (transform.position);
			playerAnimator.SetTrigger("Terminal");
			rightAnim.SetTrigger("Activate");
			leftAnim.SetTrigger("Activate");
			StartCoroutine (wait());
			}
		}
	}

	void levelComplete (){
		MenuManager.roomStart = MenuManager.RoomStart.JOURNAL;
		MenuManager.journalEntry++;
	}

	IEnumerator wait(){
		yield return new WaitForSeconds (2f);
		levelComplete ();
		hubExit.FadeToLevel (1);
	}
}
