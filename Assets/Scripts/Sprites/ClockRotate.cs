using UnityEngine;
using System.Collections;

public class ClockRotate : MonoBehaviour {

	public float rotationsPerSecond;
	float rate;

	// Use this for initialization
	void Start () {
		rate = 360f / rotationsPerSecond;
	}
	
	// Update is called once per frame
	void Update () {
	
		// Rotate the object around its local Y axis at 1 degree per second
		//transform.Rotate( Vector3.right * Time.deltaTime * rate );

		// Rotate the object around its local Y axis at 1 degree per second
		transform.Rotate( Vector3.back * Time.deltaTime * rate );

	}
}
