using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

	List<GameObject> northWallObjects = new List<GameObject>();
	List<GameObject> eastWallObjects = new List<GameObject>();
	List<GameObject> southWallObjects = new List<GameObject>();
	List<GameObject> westWallObjects = new List<GameObject>();
	private int rotationPoint = 0;
	public GameObject journalBoard;
	private Vector3 position0 = new Vector3(-4, 7, -4);
	private Vector3 position1 = new Vector3(-4, 7, 4);
	private Vector3 position2 = new Vector3(4, 7, 4);
	private Vector3 position3 = new Vector3(4, 7, -4);
	private Vector3 middle = new Vector3(0,1,0);
	private int speed = 5;

	void Start () {
		foreach(GameObject wallObject in GameObject.FindGameObjectsWithTag("NorthWallObject")){
			northWallObjects.Add (wallObject);
		}

		foreach(GameObject wallObject in GameObject.FindGameObjectsWithTag("EastWallObject")){
			eastWallObjects.Add (wallObject);
		}
		eastWallObjects.Add (journalBoard);

		foreach(GameObject wallObject in GameObject.FindGameObjectsWithTag("SouthWallObject")){
			southWallObjects.Add (wallObject);
		}

		foreach(GameObject wallObject in GameObject.FindGameObjectsWithTag("WestWallObject")){
			westWallObjects.Add (wallObject);
		}
	}

	void Update () {
		transform.LookAt (middle);

		if(Input.GetKeyUp (KeyCode.A)){
			rotationPoint++;
		}

		if(Input.GetKeyUp (KeyCode.D)){
			rotationPoint--;
		}

		if(rotationPoint > 3){
			rotationPoint = 0;
		} else if (rotationPoint < 0) {
			rotationPoint = 3;
		}
			
		if(rotationPoint == 0){
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, position0, Time.deltaTime * speed);
			foreach(GameObject wallObject in northWallObjects){
				wallObject.SetActive(true);
			}

			foreach(GameObject wallObject in eastWallObjects){
				wallObject.SetActive(false);
			}

			foreach(GameObject wallObject in southWallObjects){
				wallObject.SetActive(false);
			}

			foreach(GameObject wallObject in westWallObjects){
				wallObject.SetActive(true);
			}

		} else if(rotationPoint == 1){
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, position1, Time.deltaTime * speed);
			foreach(GameObject wallObject in northWallObjects){
				wallObject.SetActive(true);
			}

			foreach(GameObject wallObject in eastWallObjects){
				wallObject.SetActive(true);
			}

			foreach(GameObject wallObject in southWallObjects){
				wallObject.SetActive(false);
			}

			foreach(GameObject wallObject in westWallObjects){
				wallObject.SetActive(false);
			}

		} else if(rotationPoint == 2){	
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, position2, Time.deltaTime * speed);
			foreach(GameObject wallObject in northWallObjects){
				wallObject.SetActive(false);
			}

			foreach(GameObject wallObject in eastWallObjects){
				wallObject.SetActive(true);
			}

			foreach(GameObject wallObject in southWallObjects){
				wallObject.SetActive(true);
			}

			foreach(GameObject wallObject in westWallObjects){
				wallObject.SetActive(false);
			}
	
		} else if(rotationPoint == 3){
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, position3, Time.deltaTime * speed);
			foreach(GameObject wallObject in northWallObjects){
				wallObject.SetActive(false);
			}

			foreach(GameObject wallObject in eastWallObjects){
				wallObject.SetActive(false);
			}

			foreach(GameObject wallObject in southWallObjects){
				wallObject.SetActive(true);
			}

			foreach(GameObject wallObject in westWallObjects){
				wallObject.SetActive(true);
			}
		}
	}
}