using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour {

    public Text playername;
    public Text Level;
    public Text XP;
    public Image Icon;

    public Säätäjä säädin;

    public GameObject ChooseIcon;

    public Sprite Icon0; //HasNotChosenIconYet
    public Sprite Icon1;
    public Sprite Icon2;

    void Awake()
    {
        säädin = GameObject.FindGameObjectWithTag("Switch").GetComponent<Säätäjä>();
    }

    // Use this for initialization
    void Start () {

        playername.text = säädin.PlayerName.ToString();
        Level.text = säädin.PlayerLevel.ToString();
        XP.text = säädin.PlayerXP.ToString();

        if (säädin.PlayerIconID == 0)
        {
            ChooseIcon.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        #region //Icons
        if (säädin.PlayerIconID == 0)
        {
            ChooseIcon.SetActive(true);
        }
        if (säädin.PlayerIconID == 0)
        {
            Icon.sprite = Icon0;
        }
        if (säädin.PlayerIconID == 1)
        {
            Icon.sprite = Icon1;
        }
        if (säädin.PlayerIconID == 2)
        {
            Icon.sprite = Icon2;
        }
        #endregion
    }

    public void SelectIcon(int IconID)
    {
        säädin.PlayerIconID = IconID;
    }
}
