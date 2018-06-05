using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickAnimate : MonoBehaviour {

	public Animation anim;
	public string animationName;

	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0)) {
			anim.Play (animationName);
		}
	}
}