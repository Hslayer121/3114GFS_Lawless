using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalTabs : MonoBehaviour {
	
	private enum Active {None, Journal, Enemies, Abilities}
	private Active active = Active.None;
	public GameObject[] activeCatergory = new GameObject[3];

	void Start () {
		for (int i = 0; i < activeCatergory.Length; i++) {
			activeCatergory [i].SetActive (false);
		}
	}

	void Update () {
		switch (active) {
		case Active.None:
			break;
		case Active.Journal:
			for (int i = 0; i < activeCatergory.Length; i++) {
				if (i == 0) {
					activeCatergory [i].SetActive (true);
				} else {
					activeCatergory [i].SetActive (false);
				}
			}
			break;
		case Active.Enemies:
			for (int i = 0; i < activeCatergory.Length; i++) {
				if (i == 1) {
					activeCatergory [i].SetActive (true);
				} else {
					activeCatergory [i].SetActive (false);
				}
			}
			break;
		case Active.Abilities:
			for (int i = 0; i < activeCatergory.Length; i++) {
				if (i == 2) {
					activeCatergory [i].SetActive (true);
				} else {
					activeCatergory [i].SetActive (false);
				}
			}
			break;
		}
	}

	public void OpenJournal () {
		active = Active.Journal;
	}

	public void OpenEnemies () {
		active = Active.Enemies;
	}

	public void OpenAbilites () {
		active = Active.Abilities;
	}
}