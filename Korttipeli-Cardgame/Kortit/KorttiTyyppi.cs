using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    public abstract class KorttiTyyppi : ScriptableObject
    {
        public string tyyppiNimi;

        public virtual void OnSetType(KortinAsentaja asennus)
        {
            Elementti t = Settings.GetResurssiSäätäjä().tyyppiElementti;
            KortinAsennusTarpeet tyyppi = asennus.GetProperty(t); 
            tyyppi.teksti.text = tyyppiNimi; //Tällä saa kortin tyypin näkymään tekstinä kortissa, mikäli haluaa.
        }
    }
}