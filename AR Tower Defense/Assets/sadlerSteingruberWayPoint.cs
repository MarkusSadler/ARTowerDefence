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

		wayPoint.transform.position = new Vector3 (imageTarget.transform.position.x, 0, imageTarget.transform.position.z);
	}
}
