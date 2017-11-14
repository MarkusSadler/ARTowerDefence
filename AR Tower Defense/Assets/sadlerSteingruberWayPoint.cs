using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using TDTK;

public class sadlerSteingruberWayPoint : MonoBehaviour {

	public TrackableBehaviour imageTarget;

	public GameObject wayPoint;
	
	public float cameraDistance = 20;

	// Use this for initialization
	void Start ()
	{
		//cameraDistance = Camera.main.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (imageTarget.CurrentStatus != TrackableBehaviour.Status.TRACKED) {
			return;
		}

		// Camera is 50 units away from platforms
		float yCorrection = (cameraDistance - imageTarget.transform.position.y) / cameraDistance;
		float x = yCorrection != 0 ? imageTarget.transform.position.x / yCorrection : imageTarget.transform.position.x;
		float z = yCorrection != 0 ? imageTarget.transform.position.z / yCorrection : imageTarget.transform.position.z;
		wayPoint.transform.position = new Vector3 (x, 0, z);
	}
}
