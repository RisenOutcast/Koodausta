using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//@author M.J.Metsola @RisenOutcast

public class Mestarisäätäjä : MonoBehaviour {

    //Tharijas
    //Version 0.3.2

    #region //Player Details
    public string Playername;
    public string PlayerID;
    public string Email;
    public string EmailVerified;
    public string Birthday;
    public string Sex;
    public string Nickname;
    public string Country;
    public string IconID;
    public string UserSince;
    public string Dev;
    #endregion

    #region //Player Tharijas Data
    public float PlayerXP;
    public string PlayerLvl;
    #endregion

    #region //PlayData
    public bool playingAsGrontto;
    public bool playingAsAngira;
    #endregion

    public Sprite PlayerIcon1;
    public Sprite PlayerIcon2;
    public Sprite PlayerIcon3;
    public Sprite PlayerIcon4;
    public Sprite PlayerIcon5;

    public bool DevMode = false;

    void Start () {
        DontDestroyOnLoad(this.gameObject);
    }
	
	void Update () {
		if (playingAsAngira)
            playingAsGrontto = false;

        if (playingAsGrontto)
            playingAsAngira = false;
	}
}
