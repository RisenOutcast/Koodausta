using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO {
    public class KortinAsentaja : MonoBehaviour {

        public Kortti kortti;
        public KortinAsennusTarpeet[] asennusTarpeet;

        public void LataaKortti(Kortti k)
        {
            if (k == null)
                return;

            kortti = k;

            k.korttiTyyppi.OnSetType(this);

            for (int i = 0; i < k.tiedot.Length; i++)
            {
                KortinTiedot kt = k.tiedot[i];

                KortinAsennusTarpeet ka = GetProperty(kt.elementti);
                if (ka == null)
                    continue;

                if(kt.elementti is ElementtiIntti)
                {
                    ka.teksti.text = kt.intValue.ToString();
                }
                else
                if(kt.elementti is ElementtiTeksti)
                {
                    ka.teksti.text = kt.stringValue;
                }
                else
                if(kt.elementti is ElementtiKuva)
                {
                    ka.kuva.sprite = kt.sprite;
                }
            }
        }

        public KortinAsennusTarpeet GetProperty(Elementti e)
        {
            KortinAsennusTarpeet result = null;

            for (int i = 0; i < asennusTarpeet.Length; i++)
            {
                if(asennusTarpeet[i].elementti == e)
                {
                    result = asennusTarpeet[i];
                    break;
                }
            }

            return result;
        }
    }
}