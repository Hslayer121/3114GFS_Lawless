using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectHighlight : MonoBehaviour {

	public string objectName;
	private bool displayObjectName = false;

	void OnMouseOver () {
		displayObjectName = true;
	}

	void OnMouseExit () {
		displayObjectName = false;
	}

	void OnGUI () {
		if (displayObjectName) {
			Debug.Log ("HIGHLIGHTING");
			Vector2 screenPos = Event.current.mousePosition;
			Vector2 converteddGUIPos = GUIUtility.ScreenToGUIPoint (screenPos);
			GUI.Box (new Rect (converteddGUIPos.x, converteddGUIPos.y, 120, 25), objectName);
		}
	}
}

