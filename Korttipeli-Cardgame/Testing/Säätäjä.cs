using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Säätäjä : MonoBehaviour {

    public GameObject Testikortti;

    //Player Info
    public string PlayerName;
    public int PlayerLevel;
    public int PlayerXP;
    public int PlayerGamesPlayed;
    public int PlayerWins;
    public int PlayerLosses;
    public int PlayerIconID;

    //Monster Chosen
    public int ChosenMonster;

    //MonsterInfo
    public int AngiraLevel;
    public int AngiraXP;

    //OwnedCards

    public int CardID1;
    public int CardID2;
    public int CardID3;
    public int CardID4;
    public int CardID5;
    public int CardID6;
    public int CardID7;
    public int CardID8;
    public int CardID9;
    public int CardID10;
    public int CardID11;
    public int CardID12;
    public int CardID13;
    public int CardID14;
    public int CardID15;
    public int CardID16;
    public int CardID17;
    public int CardID18;
    public int CardID19;
    public int CardID20;
    public int CardID21;
    public int CardID22;
    public int CardID23;
    public int CardID24;

    //CurrentDeck
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;
    public GameObject Card6;


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        #region //Experience Points System
        if (PlayerXP < 100)
        {
            PlayerLevel = 1;
        }
        if (PlayerXP > 99)
        {
            PlayerLevel = 2;
        }
        if (PlayerXP > 299)
        {
            PlayerLevel = 3;
        }
        if (PlayerXP > 599)
        {
            PlayerLevel = 4;
        }
        if (PlayerXP > 999)
        {
            PlayerLevel = 5;
        }
        #endregion

        PlayerGamesPlayed = PlayerWins + PlayerLosses;

    }
}
