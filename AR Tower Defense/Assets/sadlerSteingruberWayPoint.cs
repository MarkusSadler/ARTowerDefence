using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class sadlerSteingruberWayPoint : MonoBehaviour {

	public TrackableBehaviour imageTarget;

	public GameObject wayPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (imageTarget.CurrentStatus != TrackableBehaviour.Status.TRACKED) {
			return;
		}

		// Camera is 50 units away from platforms
		float yCorrection = (50 - imageTarget.transform.position.y) / 50;
		float x = yCorrection != 0 ? imageTarget.transform.position.x / yCorrection : imageTarget.transform.position.x;
		float z = yCorrection != 0 ? imageTarget.transform.position.z / yCorrection : imageTarget.transform.position.z;
		wayPoint.transform.position = new Vector3 (x, 0, z);
	}
}
