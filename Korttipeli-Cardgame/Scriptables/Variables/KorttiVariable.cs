using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    [CreateAssetMenu(menuName = "Variablet/KorttiVariable")]
    public class KorttiVariable : ScriptableObject
    {
        public KorttiInstanssi value;

        public void Set(KorttiInstanssi v)
        {
            value = v;
        }
    }
}