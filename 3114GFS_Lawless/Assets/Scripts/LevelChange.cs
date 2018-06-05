using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour {

	public float yUp;
	public float yDown;

	public float speed = 2f;

	public enum PlatformMovement {Up, Down, GoingUp, GoingDown};
	public PlatformMovement platformMovement = PlatformMovement.Up;

	void Start () {
		if (platformMovement == PlatformMovement.Down) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, yDown, gameObject.transform.position.z);
		} else if (platformMovement == PlatformMovement.Up) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, yUp, gameObject.transform.position.z);
		}
	}

	void Update () {
		switch (platformMovement) {
		case PlatformMovement.Up:
			break;
		case PlatformMovement.Down:
			break;
		case PlatformMovement.GoingUp:
			MovingUp();
			break;
		case PlatformMovement.GoingDown:
			MovingDown();
			break;
		}
	}

	public void TogglePlatforms () {
		if (platformMovement == PlatformMovement.Up) {
			Lower ();
		} else if (platformMovement == PlatformMovement.Down) {
			Raise ();
		}
	}

	void Raise () {
		platformMovement = PlatformMovement.GoingUp;
	}

	void Lower () {
		platformMovement = PlatformMovement.GoingDown;
	}

	void MovingUp () {
		gameObject.transform.position += Vector3.up * speed * Time.deltaTime;

		if (gameObject.transform.position.y > yUp) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, yUp, gameObject.transform.position.z);
			platformMovement = PlatformMovement.Up;
		}
	}

	void MovingDown () {
		gameObject.transform.position += Vector3.down * speed * Time.deltaTime;

		if (gameObject.transform.position.y < yDown) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, yDown, gameObject.transform.position.z);
			platformMovement = PlatformMovement.Down;
		}
	}
}
