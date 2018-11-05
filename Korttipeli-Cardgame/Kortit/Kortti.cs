using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RO
{
    [CreateAssetMenu(fileName = "Kortti")]
    public class Kortti : ScriptableObject
    {
        public KorttiTyyppi korttiTyyppi;
        public int Hinta;
        public KortinTiedot[] tiedot;
    }
}