using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RO;

public class ShowCard : MonoBehaviour {

    public Kortti card;

    public Text nameText;
    public Text kuvaus;

    public Image artwork;

    public Text korttinumero;

	// Use this for initialization
	void Start () {

        nameText.text = card.name;
        //kuvaus.text = card.description;

        //artwork.sprite = card.kuva;

        //korttinumero.text = card.cardnumber;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
