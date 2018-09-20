using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    public class KorttiInstanssi : MonoBehaviour, IClickable
    {
        public KortinAsentaja asentaja;
        public RO.GameElements.GameElementLogic currentLogic;

        void Start()
        {
            asentaja = GetComponent<KortinAsentaja>();
        }

        public void OnClick()
        {
            if (currentLogic == null)
                return;

            currentLogic.OnClick(this);
        }

        public void OnHighlight()
        {
            if (currentLogic == null)
                return;

            currentLogic.OnHighlight(this);
        }
    }
}