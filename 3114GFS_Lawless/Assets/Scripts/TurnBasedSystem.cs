using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedSystem : MonoBehaviour {

	public float resetTime = 2f;
	public List<TurnClass> playersGroup;

	// Use this for initialization
	void Start () {
		ResetTurns ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTurns ();
	}

	void ResetTurns () {
		for (int i = 0; i < playersGroup.Count; i++) {
			if (i == 0) {
				playersGroup [i].isTurn = true;
				playersGroup [i].wasTurnPrev = false;
			} else {
				playersGroup [i].isTurn = false;
				playersGroup [i].wasTurnPrev = false;
			}
		}
	}

	void UpdateTurns () {
		for (int i = 0; i < playersGroup.Count; i++) {
			if (!playersGroup[i].wasTurnPrev) {
				playersGroup[i].isTurn = true;
				break;
			} else if (i == playersGroup.Count - 1 && playersGroup[i].wasTurnPrev) {
				StartCoroutine ("ResetDelay");
			}
		}
	}

	IEnumerator ResetDelay () {
		yield return new WaitForSeconds (resetTime);
		ResetTurns ();
		StopCoroutine ("ResetDelay");
	}
}

[System.Serializable]
public class TurnClass {
	public GameObject character;
	public bool isTurn = false;
	public bool wasTurnPrev = true;
}
