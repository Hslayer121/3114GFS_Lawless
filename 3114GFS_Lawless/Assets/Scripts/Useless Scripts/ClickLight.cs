using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLight : MonoBehaviour {

	public Light light;
	public float transitionSpeed = 0.5f;
	public float lowIntensity = 0f;
	public float highIntensity = 1f;
	private bool lightChange = false;
	private float t = 0.0f;
	public bool lightUp = true;

	void OnMouseDown(){
		lightChange = true;
	}

	void OnMouseUp(){
		lightChange = false;
	}

	void Awake(){
		light.intensity = 0.25f;
	}
		

	void Update() {
		if (light.intensity == highIntensity) {
			lightUp = false;
		} else if (light.intensity == lowIntensity) {
			lightUp = true;
		}

		if (lightChange && lightUp) {
			t += transitionSpeed *Time.deltaTime; 
			light.intensity = Mathf.Lerp (lowIntensity, highIntensity, t);
			if(light.intensity == highIntensity && lightUp){
				t = 0f;
			}
		}	

		if(lightChange && !lightUp){
			t += transitionSpeed *Time.deltaTime;
			light.intensity = Mathf.Lerp (highIntensity, lowIntensity, t);
			if (light.intensity == lowIntensity && !lightUp) {
				t = 0f;
			}
		}
	} 
}