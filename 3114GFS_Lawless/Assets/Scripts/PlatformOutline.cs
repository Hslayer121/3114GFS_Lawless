using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOutline : MonoBehaviour {
	
	private List<GameObject> platforms = new List<GameObject>();			// A list of all the platforms in the scene
	private float north;													
	private float east;
	private float south;
	private float west;

	public GameObject outlineBlueNorth;	
	public GameObject outlineBlueEast;
	public GameObject outlineBlueSouth;
	public GameObject outlineBlueWest;

	public GameObject outlineRedNorth;	
	public GameObject outlineRedEast;
	public GameObject outlineRedSouth;
	public GameObject outlineRedWest;

	private bool redNorth = true;
	private bool redEast = true;
	private bool redSouth = true;
	private bool redWest = true;

	private bool blueNorth = true;
	private bool blueEast = true;
	private bool blueSouth = true;
	private bool blueWest = true;

	private bool scanned = false;

	void Start () {
		foreach (GameObject platform in GameObject.FindGameObjectsWithTag("Platform")) {		// For each object in the scene tagged "Platform"...
			platforms.Add (platform);															// ...Add it to the list "platforms"
		}

		east = transform.position.x + 2;														//Directly East is considered an object thats x value is +2 of my own
		west = transform.position.x - 2;														//Directly West is considered an object thats x value is -2 of my own
		north = transform.position.z + 2;														//Directly North is considered an object thats z value is +2 of my own
		south = transform.position.z - 2;														//Directly South is considered an object thats z value is -2 of my own
	}

	void Update () {
		foreach(GameObject platform in platforms){																		//For each of the platforms in the scene...
			if(platform.transform.position.x == transform.position.x && platform.transform.position.z == north && platform.transform.position.y == transform.position.y){		//If a platform is north of me (ie. has the same x value but their z value is +2 of my own)
				blueNorth = false;																		//That platform is direclty north of me and so turn off the blue light outline on my north
				redNorth = false;
			}

			if (platform.transform.position.z == transform.position.z && platform.transform.position.x == east && platform.transform.position.y == transform.position.y) {		//If a platform is east of me (ie. has the same z value but their x value is +2 of my own)
				blueEast = false;																			//That platform is direclty east of me and so turn off the blue light outline on my east
				redEast = false;
			} 
				
			if(platform.transform.position.x == transform.position.x && platform.transform.position.z == south && platform.transform.position.y == transform.position.y){		//If a platform is south of me (ie. has the same x value but their z value is -2 of my own)
				blueSouth = false;																			//That platform is direclty south of me and so turn off the blue light outline on my south
				redSouth = false;
			}

			if(platform.transform.position.z == transform.position.z && platform.transform.position.x == west && platform.transform.position.y == transform.position.y){			//If a platform is west of me (ie. has the same z value but their x value is -2 of my own)
				blueWest = false;																			//That platform is direclty west of me and so turn off the blue light outline on my west
				redWest = false;
			}
				
			if (scanned) {
				if (redEast) {
					outlineBlueEast.SetActive (false);
					outlineRedEast.SetActive (true);
				}

				if (redNorth) {
					outlineBlueNorth.SetActive (false);
					outlineRedNorth.SetActive (true);
				} 

				if (redWest) {
					outlineBlueWest.SetActive (false);
					outlineRedWest.SetActive (true);
				} 

				if (redSouth) {
					outlineBlueSouth.SetActive (false);
					outlineRedSouth.SetActive (true);
				}
			} else if (!scanned) {
				if (blueEast) {
					outlineBlueEast.SetActive (true);
					outlineRedEast.SetActive (false);
				} else {
					outlineBlueEast.SetActive (false);
				}

				if (blueNorth) {
					outlineBlueNorth.SetActive (true);
					outlineRedNorth.SetActive (false);
				} else {
					outlineBlueNorth.SetActive (false);
				}

				if (blueWest) {
					outlineBlueWest.SetActive (true);
					outlineRedWest.SetActive (false);
				} else {
					outlineBlueWest.SetActive (false);
				}

				if (blueSouth) {
					outlineBlueSouth.SetActive (true);
					outlineRedSouth.SetActive (false);
				} else {
					outlineBlueSouth.SetActive (false);
				}
			}
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.name == "ScannerBar") {
			scanned = true;
		}
	}

	void OnCollisionExit(Collision other){
		if (other.gameObject.name == "ScannerBar") {
			scanned = false;
		}
	}
}
