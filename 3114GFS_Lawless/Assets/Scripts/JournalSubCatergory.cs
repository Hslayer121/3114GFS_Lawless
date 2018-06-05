using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalSubCatergory : MonoBehaviour {

	private enum ActiveSub {None, One, Two, Three, Four}
	private ActiveSub activeSub = ActiveSub.None;
	public GameObject[] activeCatergory = new GameObject[4];

	void Start () {
		for (int i = 0; i < activeCatergory.Length; i++) {
			activeCatergory [i].SetActive (false);
		}
	}
	
	void Update () {
		switch (activeSub) {
		case ActiveSub.None:
			break;
		case ActiveSub.One:
			for (int i = 0; i < activeCatergory.Length; i++) {
				if (i == 0) {
					activeCatergory [i].SetActive (true);
				} else {
					activeCatergory [i].SetActive (false);
				}
			}
			break;
		case ActiveSub.Two:
			for (int i = 0; i < activeCatergory.Length; i++) {
				if (i == 1) {
					activeCatergory [i].SetActive (true);
				} else {
					activeCatergory [i].SetActive (false);
				}
			}
			break;
		case ActiveSub.Three:
			for (int i = 0; i < activeCatergory.Length; i++) {
				if (i == 2) {
					activeCatergory [i].SetActive (true);
				} else {
					activeCatergory [i].SetActive (false);
				}
			}
			break;
		case ActiveSub.Four:
			for (int i = 0; i < activeCatergory.Length; i++) {
				if (i == 3) {
					activeCatergory [i].SetActive (true);
				} else {
					activeCatergory [i].SetActive (false);
				}
			}
			break;
		}
	}

	public void OpenOne () {
		activeSub = ActiveSub.One;
	}

	public void OpenTwo () {
		activeSub = ActiveSub.Two;
	}

	public void OpenThree () {
		activeSub = ActiveSub.Three;
	}

	public void OpenFour () {
		activeSub = ActiveSub.Four;
	}
}
