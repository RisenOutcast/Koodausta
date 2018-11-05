using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchResults : MonoBehaviour {

    public GameObject VictoryText;
    public GameObject DefeatText;

    public bool Victory;
    public bool Defeat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Victory == true)
        {
            VictoryText.SetActive(true);
        }

        if(Defeat == true)
        {
            DefeatText.SetActive(true);
        }
	}
}
