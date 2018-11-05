using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUDElements : MonoBehaviour {

    public Text Playername;

    public Säätäjä säädin;

    void Awake()
    {
        säädin = GameObject.FindGameObjectWithTag("Switch").GetComponent<Säätäjä>();
    }

    // Use this for initialization
    void Start () {
        Playername.text = säädin.PlayerName.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
