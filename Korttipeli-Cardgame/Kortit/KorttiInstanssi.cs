using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    public class KorttiInstanssi : MonoBehaviour, IClickable
    {
        public KortinAsentaja asentaja;
        public RO.GameElements.GameElementLogic currentLogic;
        public bool isUsable; //If this card can do other things, such as attacking.
        Transform Back;
        Transform Raycast
;
        void Start()
        {
            asentaja = GetComponent<KortinAsentaja>();
            Back = this.gameObject.transform.GetChild(0).GetChild(9);
        }

        void Update()
        {
            if (Back == null)
                Back = this.gameObject.transform.GetChild(0).GetChild(9);

            if(Raycast == null)
                Raycast = this.gameObject.transform.GetChild(0).GetChild(0);

            if (this.transform.parent.gameObject.CompareTag("EnemyHand"))
            {
                if(!Back.gameObject.activeSelf)
                    Back.gameObject.SetActive(true);
                if (Raycast.gameObject.activeSelf)
                    Raycast.gameObject.SetActive(false);
            }
            if (!this.transform.parent.gameObject.CompareTag("EnemyHand"))
            {
                if (Back.gameObject.activeSelf)
                    Back.gameObject.SetActive(false);
                if (!Raycast.gameObject.activeSelf)
                    Raycast.gameObject.SetActive(true);
            }

            if (!this.transform.parent.gameObject.CompareTag("EnemyTable"))
            {
                if (!Raycast.gameObject.activeSelf)
                    Raycast.gameObject.SetActive(true);
            }

            if (this.transform.parent.gameObject.CompareTag("EnemyTable"))
            {
                if (Raycast.gameObject.activeSelf)
                    Raycast.gameObject.SetActive(false);
            }
        }

        public void OnClick()
        {
            if (currentLogic == null)
                return;

            currentLogic.OnClick(this);
        }

        public void OnHighlight()
        {
            if (currentLogic == null)
                return;

            currentLogic.OnHighlight(this);
        }

        public void CardInstanceToGraveyard()
        {
            Settings.peliSäätäjä.PutCardToGraveyard(this);
        }
    }
}