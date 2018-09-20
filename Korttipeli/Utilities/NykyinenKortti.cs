using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    public class NykyinenKortti : MonoBehaviour
    {
        public KorttiVariable nykyinenKortti;
        public KortinAsentaja asentaja;

        Transform Transformi;

        public void LataaKortti()
        {
            if (nykyinenKortti.value == null)
                return;

            nykyinenKortti.value.gameObject.SetActive(false);
            asentaja.LataaKortti(nykyinenKortti.value.asentaja.kortti);
            asentaja.gameObject.SetActive(true);
        }

        public void SuljeKortti()
        {
            asentaja.gameObject.SetActive(false);
        }

        private void Start()
        {
            Transformi = this.transform;
            SuljeKortti();
        }

        void Update()
        {
            Transformi.position = Input.mousePosition;
        }
    }
}