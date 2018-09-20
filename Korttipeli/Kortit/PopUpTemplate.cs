using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RO
{
    public class PopUpTemplate : MonoBehaviour
    {

        public Kortti card;
        public Text nameText;
        public Text kuvaus;
        public Image artwork;
        public Text korttinumero;

        KortinToiminta ActiveCard = null;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ActiveCard = GameObject.FindGameObjectWithTag("ActiveCard").GetComponent<KortinToiminta>();

            card = ActiveCard.kortti;

            //nameText.text = card.name;
            //kuvaus.text = card.description;
            //artwork.sprite = card.kuva;
            //korttinumero.text = card.cardnumber;
        }
    }
}