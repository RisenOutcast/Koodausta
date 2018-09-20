using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

namespace RO
{
    public class KortinToiminta : MonoBehaviour//, IPointerDownHandler
    {

        public TMP_Text nameText;
        public TMP_Text kuvaus;
        public Image artwork;
        public TMP_Text korttinumero;

        public Kortti kortti;

        public Monster monster1;

        public int addhealth;
        public int addattack;
        public int adddefence;
        public float addmaxhealth;

        public float oldhealth;
        public float healthscale;

        // Use this for initialization
        void Start()
        {
            //LoadCard(kortti);

            //addhealth = card.addhealth;
            //addattack = card.addattack;
            //adddefence = card.adddefence;
            //addmaxhealth = card.addmaxhealth;

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

        //public void LoadCard(Kortti c)
        //{
            //if (c == null)
                //return;

            //kortti = c;
            //nameText.text = c.name;
            //kuvaus.text = c.description;
            //artwork.sprite = c.kuva;
            //korttinumero.text = c.cardnumber;
        //}

        //public void OnPointerDown(PointerEventData pointerEventData)
        //{
            //monster1.attack += addattack;
            //monster1.defence += adddefence;
            //monster1.health += addhealth;

            //if (addmaxhealth > 0)
                //StartCoroutine(OldHealth());

            //Destroy(this.gameObject, 5);
        //}

        //IEnumerator OldHealth()
        //{
            //oldhealth = monster1.maxhealth;
            //yield return new WaitForSeconds(0.0001F);
            //monster1.maxhealth += addmaxhealth;
            //yield return new WaitForSeconds(0.0001F);
            //healthscale = monster1.maxhealth / oldhealth;
            //monster1.health = monster1.health * healthscale;
        //}
    //}
//}