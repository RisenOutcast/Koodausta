using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.GameElements
{
    public class Alue : MonoBehaviour
    {
        public AlueLogiikka logiikka;

        public void OnDrop()
        {
            logiikka.Execute();
        }
    }
}