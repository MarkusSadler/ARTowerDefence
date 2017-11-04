using System;
using System.Collections;
using System.Collections.Generic;
using TDTK;
using UnityEditor;
using UnityEngine;
using Vuforia;

public class sadlerSteingruberTower : MonoBehaviour
{
    public TrackableBehaviour imageTarget;

    public GameObject platform;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (imageTarget.CurrentStatus != TrackableBehaviour.Status.TRACKED)
        {
            return;
        }

        Transform oldPlatformTransform = platform.transform;

        // Camera is 50 units away from platforms
        float yCorrection = (50 - imageTarget.transform.position.y) / 50;
        float x = Math.Abs(yCorrection) > 0.01
            ? imageTarget.transform.position.x / yCorrection
            : imageTarget.transform.position.x;
        float z = Math.Abs(yCorrection) > 0.01
            ? imageTarget.transform.position.z / yCorrection
            : imageTarget.transform.position.z;
        Vector3 newPlatformPosition = new Vector3(x, 0, z);


        GameObject[] rootGameObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject g in rootGameObjects)
        {
            if (g.layer == LayerMask.NameToLayer("Tower"))
            {
                Vector3 pos = BuildManager.GetTilePos(oldPlatformTransform, g.transform.position);
                Vector3 diff = pos - oldPlatformTransform.position;

                g.transform.position = newPlatformPosition + diff;
                break;
            }
        }

        platform.transform.position = newPlatformPosition;
    }
}