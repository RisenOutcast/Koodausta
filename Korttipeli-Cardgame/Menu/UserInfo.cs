using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour {

    public Text playername;
    public Text Level;
    public Text XP;
    public Image Icon;

    public Mestarisäätäjä Mestari;

    public GameObject ChooseIcon;

    public Sprite Icon0; //HasNotChosenIconYet
    public Sprite Icon1;
    public Sprite Icon2;
    public Sprite Icon3;
    public Sprite Icon4;
    public Sprite Icon5;

    void Awake()
    {
        Mestari = GameObject.FindWithTag("Mestari").GetComponent<Mestarisäätäjä>();
    }

    // Use this for initialization
    void Start () {

        playername.text = Mestari.Playername.ToString();

        if (Mestari.IconID == 0.ToString())
        {
            ChooseIcon.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Mestari == null)
        {
            GameObject.FindWithTag("Mestari").GetComponent<Mestarisäätäjä>();
        }

        #region //Icons
        if (Mestari.IconID == 0.ToString())
        {
            ChooseIcon.SetActive(true);
        }
        if (Mestari.IconID == 1.ToString())
        {
            Icon.sprite = Icon0;
        }
        if (Mestari.IconID == 2.ToString())
        {
            Icon.sprite = Icon1;
        }
        if (Mestari.IconID == 3.ToString())
        {
            Icon.sprite = Icon2;
        }
        if (Mestari.IconID == 4.ToString())
        {
            Icon.sprite = Icon3;
        }
        if (Mestari.IconID == 5.ToString())
        {
            Icon.sprite = Icon4;
        }
        if (Mestari.IconID == 6.ToString())
        {
            Icon.sprite = Icon5;
        }
        #endregion
    }

    public void SelectIcon(string IconID)
    {
        Mestari.IconID = IconID.ToString();
    }
}
