using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour {

	public Text displayText;
	public Text[] information = new Text[4];

	private enum ActiveJournal {None, One, Two, Three, Four};
	private ActiveJournal activeJournal = ActiveJournal.None;

	public GameObject[] activeButton = new GameObject[4];

	void start () {
		for (int i = 0; i < activeButton.Length; i++) {
			activeButton [i].SetActive (false);
		}
	}

	void Update () {
		switch (activeJournal) {
		case ActiveJournal.None:
			break;
		case ActiveJournal.One:
			for (int i = 0; i < activeButton.Length; i++) {
				if (i == 0) {
					activeButton [i].SetActive (true);
				} else {
					activeButton [i].SetActive (false);
				}
			}
			break;
		case ActiveJournal.Two:
			for (int i = 0; i < activeButton.Length; i++) {
				if (i == 1) {
					activeButton [i].SetActive (true);
				} else {
					activeButton [i].SetActive (false);
				}
			}
			break;
		case ActiveJournal.Three:
			for (int i = 0; i < activeButton.Length; i++) {
				if (i == 2) {
					activeButton [i].SetActive (true);
				} else {
					activeButton [i].SetActive (false);
				}
			}
			break;
		case ActiveJournal.Four:
			for (int i = 0; i < activeButton.Length; i++) {
				if (i == 3) {
					activeButton [i].SetActive (true);
				} else {
					activeButton [i].SetActive (false);
				}
			}
			break;
		}
	}

	public void Information01 () {
		activeJournal = ActiveJournal.One;
		displayText.text = information[0].text;
		Debug.Log ("Entry01");
	}

	public void Infromation02 () {
		activeJournal = ActiveJournal.Two;
		displayText.text = information[1].text;
		Debug.Log ("Entry02");
	}

	public void Information03 () {
		activeJournal = ActiveJournal.Three;
		displayText.text = information[2].text;
		Debug.Log ("Entry03");
	}

	public void Information04 () {
		activeJournal = ActiveJournal.Four;
		displayText.text = information[3].text;
		Debug.Log ("Entry04");
	}
}