using UnityEngine;
using System.Collections;

public class TacticalScroller : MonoBehaviour {

	readonly float minimum = 50f;
	readonly float scrollSpeed = -100f;   // negative means scroll down = bigger view

	void Update() {

		float maximum = getMaximum ();

		float distance = Camera.main.orthographicSize;
		distance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
		distance = Mathf.Clamp(distance, minimum, maximum);

		// NOTE: orthographicSize is the Vertical pixels
		Camera.main.orthographicSize = distance;
	}

	// Camera.main.orthographicSize is the vertical pixels
	// need to also account for horizontal pixels
	float getMaximum(){
		float vertical = TacticalShared.map.visualYOffset ();
		float horizontal = TacticalShared.map.visualXOffset () * Screen.height / Screen.width;
		return (vertical > horizontal ? vertical : horizontal);
	}

}
