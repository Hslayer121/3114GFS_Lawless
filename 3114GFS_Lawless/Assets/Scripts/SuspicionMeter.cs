using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SuspicionMeter : MonoBehaviour {
	
	public float currentSuspicion = 0;							// The current suspicion level of the player, public so other scripts can affect it.
	//private int suspicionLimit = 5;								// The limit of how high the suspicion can be before game over/ restart
	public GameObject[] suspicionUI = new GameObject[4];

	void Update () {
		//string sceneName = SceneManager.GetActiveScene ().name;

		if (currentSuspicion == 1) {
			suspicionUI[0].SetActive(true);
		} else if (currentSuspicion == 2) {
			suspicionUI[1].SetActive(true);
			GameObject.Find ("Player").GetComponent<TurnTimer> ().countdown = 5;
		} else if (currentSuspicion == 3) {
			suspicionUI[2].SetActive(true);
		} else if (currentSuspicion == 4){
			suspicionUI[3].SetActive(true);
		}

		//if(currentSuspicion >= suspicionLimit){					//If the suspicion level excedes the limit...
			//SceneManager.LoadScene (sceneName);					//...Restart game
		//}
	}
}
