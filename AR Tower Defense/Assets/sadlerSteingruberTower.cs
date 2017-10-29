using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class sadlerSteingruberTower : MonoBehaviour {

	public TrackableBehaviour imageTarget;

	public GameObject platform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (imageTarget.CurrentStatus != TrackableBehaviour.Status.TRACKED) {
			return;
		}

		Vector3 oldPlatformPosition = imageTarget.transform.position;

		// Camera is 50 units away from platforms
		float yCorrection = (50 - imageTarget.transform.position.y) / 50;
		float x = yCorrection != 0 ? imageTarget.transform.position.x / yCorrection : imageTarget.transform.position.x;
		float z = yCorrection != 0 ? imageTarget.transform.position.z / yCorrection : imageTarget.transform.position.z;
		platform.transform.position = new Vector3 (x, 0, z);

		GameObject[] rootGameObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene ().GetRootGameObjects ();
		foreach (GameObject g in rootGameObjects) {
			if (g.layer == LayerMask.NameToLayer("Tower")) {
				float xRelativeToPlatform = oldPlatformPosition.x - oldPlatformPosition.x / yCorrection;
				float zRelativeToPlatform = g.transform.position.z - oldPlatformPosition.z / yCorrection;
				g.transform.position = new Vector3 (x + xRelativeToPlatform, 0, z + zRelativeToPlatform);
			}
		}
	}
}
