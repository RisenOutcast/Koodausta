using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RO
{
    [CreateAssetMenu(fileName = "Kortti")]
    public class Kortti : ScriptableObject
    {
        [System.NonSerialized]
        public int instId;

        [System.NonSerialized]
        public KortinAsentaja kortinAsentaja;

        public KorttiTyyppi korttiTyyppi;
        public int Hinta;
        public KortinTiedot[] tiedot;
        public int AddHealth;
        public int AddAttack;
        public int AddDefence;
        public int AddArmor;
        public int AddImpact;
        public int AddPierce;
        public int AddPhas;
        public int AddAbas;
        public int AddTygo;
        public int AddMinionHealth;
        public int TakeHealth;
        public int TakeAttack;
        public int TakeDefence;

        //Special Cards
        public bool Death;
        public bool Shaman;
        public bool Raven;
    }
}