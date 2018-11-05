using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Konsoli
{
    [CreateAssetMenu(menuName ="Konsoli/Hook")]
    public class KonsoliHook : ScriptableObject
    {
        [System.NonSerialized]
        public KonsoliManageri konsoliManageri;

        public void RegisterEvent(string s, Color color)
        {
            konsoliManageri.RegisterEvent(s, color);
        }
    }
}