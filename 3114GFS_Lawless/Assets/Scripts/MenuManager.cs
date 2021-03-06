using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	private Camera cameraMain;

	public MeshCollider forum;
	public MeshCollider journal;
	public MeshCollider hacking;
	public MeshCollider quit;
	public MeshCollider options;

	public Transform canvas;
	public Transform forumScreen;
	public Transform journalScreen;
	public Transform hackingScreen;
	public Transform exitScreen;
	public Transform optionsScreen;

	public enum RoomStart { ROOM, JOURNAL, LEVEL, CHAT };
	public static RoomStart roomStart = RoomStart.CHAT;
	public static int journalEntry = 0;
	public static int chatIndex = 0;
	public static int levelCompleted = 0;

	private float timer = 0f;
	public int flashSpeed = 0;
	private bool alarmActive = false;
	public GameObject journalAlarm;
	public GameObject chatAlarm;
	public GameObject levelAlarm;

	private HubExit hubExit;

	void Start () {
		cameraMain = Camera.main;
		hubExit = GameObject.Find ("ScreenFade").GetComponent<HubExit> ();
	}

	void Update () {
		timer += Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.Z)) {
			roomStart = RoomStart.CHAT;
		} else if (Input.GetKeyDown (KeyCode.X)) {
			roomStart = RoomStart.LEVEL;
		} else if (Input.GetKeyDown (KeyCode.C)) {
			roomStart = RoomStart.JOURNAL;
		}

		switch (roomStart) {
		case RoomStart.ROOM:
			RoomNext ();
			break;
		case RoomStart.CHAT:
			ChatNext ();
			break;
		case RoomStart.JOURNAL:
			JournalNext ();
			break;
		case RoomStart.LEVEL:
			LevelNext ();
			break;
		}

		RaycastHit hit;
		Ray ray = cameraMain.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out hit)) {
			if (Input.GetMouseButtonDown (0)) {
				if (hit.collider.gameObject.tag == ("Forum")) {
					ForumPause ();
				} else if (hit.collider.gameObject.tag == ("Journal")) {
					JournalPause ();
				} else if (hit.collider.gameObject.tag == ("Hacking")) {
					HackingPause ();
				} else if (hit.collider.gameObject.name == ("slideDoor")) {
					ExitPause ();
				} else if (hit.collider.gameObject.tag == ("Options")) {
					OptionsPause ();
				}
			} 
		}
	}

	void RoomNext () {
		//This is where we write the code that alters the room to make it highlight the next selection for the player
	}

	void ChatNext () {
		journalAlarm.SetActive (false);
		levelAlarm.SetActive (false);

		if (timer > flashSpeed) {
			if (alarmActive) {
				chatAlarm.SetActive (false);
				alarmActive = false;
			} else if (!alarmActive) {
				chatAlarm.SetActive (true);
				alarmActive = true;
			}
			timer = 0;
		}
	}

	void JournalNext () {
		chatAlarm.SetActive (false);
		levelAlarm.SetActive (false);

		if (timer > flashSpeed) {
			if (alarmActive) {
				journalAlarm.SetActive (false);
				alarmActive = false;
			} else if (!alarmActive) {
				journalAlarm.SetActive (true);
				alarmActive = true;
			}
			timer = 0;
		}
	}

	void LevelNext () {
		journalAlarm.SetActive (false);
		chatAlarm.SetActive (false);

		if (timer > flashSpeed) {
			if (alarmActive) {
				levelAlarm.SetActive (false);
				alarmActive = false;
			} else if (!alarmActive) {
				levelAlarm.SetActive (true);
				alarmActive = true;
			}
			timer = 0;
		}
	}
		
	public void ForumPause () {
		Debug.Log ("OPEN FORUM");
		if (canvas.gameObject.activeInHierarchy == false)
		{
			canvas.gameObject.SetActive(true);
			forumScreen.gameObject.SetActive (true);

			forum.enabled = false;
			journal.enabled = false;
			hacking.enabled = false;
			quit.enabled = false;
			options.enabled = false;
		} else {
			canvas.gameObject.SetActive(false);
			forumScreen.gameObject.SetActive (false);

			forum.enabled = true;
			journal.enabled = true;
			hacking.enabled = true;
			quit.enabled = true;
			options.enabled = true;
		}
	}

	public void JournalPause () {
		Debug.Log ("OPEN JOURNAL");
		if (canvas.gameObject.activeInHierarchy == false)
		{
			canvas.gameObject.SetActive(true);
			journalScreen.gameObject.SetActive (true);

			forum.enabled = false;
			journal.enabled = false;
			hacking.enabled = false;
			quit.enabled = false;
			options.enabled = false;
		} else {
			canvas.gameObject.SetActive(false);
			journalScreen.gameObject.SetActive (false);

			forum.enabled = true;
			journal.enabled = true;
			hacking.enabled = true;
			quit.enabled = true;
			options.enabled = true;
		}
	}

	public void HackingPause () {
		Debug.Log ("OPEN HACKING");
		if (canvas.gameObject.activeInHierarchy == false)
		{
			canvas.gameObject.SetActive(true);
			hackingScreen.gameObject.SetActive (true);

			forum.enabled = false;
			journal.enabled = false;
			hacking.enabled = false;
			quit.enabled = false;
			options.enabled = false;
		} else {
			canvas.gameObject.SetActive(false);
			hackingScreen.gameObject.SetActive (false);

			forum.enabled = true;
			journal.enabled = true;
			hacking.enabled = true;
			quit.enabled = true;
			options.enabled = true;
		}
	}

	public void ExitPause () {
		Debug.Log ("OPEN EXIT");
		if (canvas.gameObject.activeInHierarchy == false)
		{
			canvas.gameObject.SetActive(true);
			exitScreen.gameObject.SetActive (true);

			forum.enabled = false;
			journal.enabled = false;
			hacking.enabled = false;
			quit.enabled = false;
			options.enabled = false;
		} else {
			canvas.gameObject.SetActive(false);
			exitScreen.gameObject.SetActive (false);

			forum.enabled = true;
			journal.enabled = true;
			hacking.enabled = true;
			quit.enabled = true;
			options.enabled = true;
		}
	}

	public void OptionsPause () {
		Debug.Log ("OPEN OPTIONS");
		if (canvas.gameObject.activeInHierarchy == false)
		{
			canvas.gameObject.SetActive(true);
			optionsScreen.gameObject.SetActive (true);

			forum.enabled = false;
			journal.enabled = false;
			hacking.enabled = false;
			quit.enabled = false;
			options.enabled = false;
		} else {
			canvas.gameObject.SetActive(false);
			optionsScreen.gameObject.SetActive (false);

			forum.enabled = true;
			journal.enabled = true;
			hacking.enabled = true;
			quit.enabled = true;
			options.enabled = true;
		}
	}

	public void QuitGameMenu (bool Quit) {
		if (Quit) {
			Application.Quit();
			Debug.Log ("Quit Game");
		}
	}

	public void StartLevelTutorial (bool Tut) {
		if (Tut) {
			hubExit.FadeToLevel (5);
		}
	}

	public void StartLevel01 (bool One) {
		if (One) {
			hubExit.FadeToLevel (6);
		}
	}

	public void StartLevel02 (bool Two) {
		if (Two) {
			hubExit.FadeToLevel (7);
		}
	}

	public void StartLevel03 (bool Three) {
		if (Three) {
			hubExit.FadeToLevel (8);
		}
	}

	public void StartLevel04 (bool Four) {
		if (Four) {
			hubExit.FadeToLevel (9);
		}
	}

	public void StartLevel05 (bool Five) {
		if (Five) {
			hubExit.FadeToLevel (10);
		}
	}
}