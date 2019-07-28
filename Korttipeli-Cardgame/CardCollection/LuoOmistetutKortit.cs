using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuoOmistetutKortit : MonoBehaviour {

    public Säätäjä säädin;

    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;
    public GameObject Card6;

    // Use this for initialization
    void Start () {
        säädin = GameObject.FindGameObjectWithTag("Switch").GetComponent<Säätäjä>();

        if(säädin.CardID1 > 0)
        {
            Card1.SetActive(true);
        }
        if (säädin.CardID2 > 0)
        {
            Card2.SetActive(true);
        }
        if (säädin.CardID3 > 0)
        {
            Card3.SetActive(true);
        }
        if (säädin.CardID4 > 0)
        {
            Card4.SetActive(true);
        }
        if (säädin.CardID5 > 0)
        {
            Card5.SetActive(true);
        }
        if (säädin.CardID6 > 0)
        {
            Card6.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
