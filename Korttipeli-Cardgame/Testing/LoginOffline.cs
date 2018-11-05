using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginOffline : MonoBehaviour {

    public Text playername;
    public Text Icon;
    public Text XP;


    public Säätäjä säädin;

    // Use this for initialization
    void Start () {
        säädin = GameObject.FindGameObjectWithTag("Switch").GetComponent<Säätäjä>();
    }
	
	// Update is called once per frame
	void Update () {
        säädin.PlayerName = playername.text;
        säädin.PlayerIconID = int.Parse(Icon.text);
        säädin.PlayerXP = int.Parse(XP.text);
    }
}
