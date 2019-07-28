using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEarth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(0, +0.2F, 0);
	}
}
