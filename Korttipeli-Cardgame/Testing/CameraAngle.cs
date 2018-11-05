using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngle : MonoBehaviour {

    public Camera cam;
    public Vector3 dir;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        dir = cam.transform.position - transform.parent.forward;
        var enemyAngle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;

        Debug.Log("Angle from the player is: " + enemyAngle);
    }
}
