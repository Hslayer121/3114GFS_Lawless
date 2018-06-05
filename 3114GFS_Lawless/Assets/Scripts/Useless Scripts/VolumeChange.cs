using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour {

	private float soundChange = 0.02f;
	private float soundHigh = 0.1f;
	private float soundOff = 0f;
	public float globalSound = 0f;
	public bool soundUp = true;
	public AudioSource sound;

	void Update(){
		sound.volume = globalSound;
	}

	void OnMouseDown(){
		if(soundUp){
			globalSound += soundChange;
			if(globalSound >= soundHigh){
					soundUp = false;
				sound.volume = 0.1f;
			}
		}

		if(!soundUp){
			globalSound -= soundChange;
			if(globalSound == soundOff){
					soundUp = true;
				sound.volume = 0f;
				}
		}
	}
}
