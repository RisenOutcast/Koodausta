using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    [CreateAssetMenu(menuName = "Holders/Card Holder")]
    public class CardHolders : ScriptableObject
    {
        public RO.TransformiVariable käsiGridi;
        public RO.TransformiVariable pöytäGridi;
        public RO.TransformiVariable rahaGridi;
        public RO.TransformiVariable minioniGridi;

        public void LoadPlayer(PlayerHolder p)
        {
            foreach (KorttiInstanssi k in p.kortitPöydällä)
            {
                k.asentaja.transform.SetParent(pöytäGridi.value.transform);
            }

            foreach (KorttiInstanssi k in p.kortitKädes)
            {
                k.asentaja.transform.SetParent(käsiGridi.value.transform);
            }

            foreach (CoinHolder k in p.coinlist)
            {
                k.cardObject.transform.SetParent(rahaGridi.value.transform);
            }
        }
    }
}