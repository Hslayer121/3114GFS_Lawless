using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffect : MonoBehaviour {

	public GameObject effect;

	void OnMouseDown(){
		effect.SetActive (true);
	}
}