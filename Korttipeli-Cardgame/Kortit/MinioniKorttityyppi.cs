﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    [CreateAssetMenu(menuName = "Kortti Tyypit/Minioni")]
    public class MinioniKorttityyppi : KorttiTyyppi
    {

        public override void OnSetType(KortinAsentaja asennus)
        {
            base.OnSetType(asennus);

            //Jos lisää tänne esim. KortinAsentaja.JokuMikäPitääPeittää/LisätäKorttiin.SetActive(true/false) niin saa peiteltyä tai esiteltyä jonkun osan kortista.
            //Se pitää sitten myös lisätä gameobjectiksi tonne KortinAsentajaan!
        }
    }
}