using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RO.UI
{
    public class UIPropertyUpdater : PeliEventtiListener
    {
        /// <summary>
        /// Use this to update the UI element as soon as THIS gameObject is enabled
        /// </summary>
        public bool raiseOnEnable;
        /// In the off chance you need to update a UI element when disabled, just add the OnDisable() method

        /// <summary>
        /// If there's a gameEvent assigned it will automaticall call the Raise() method.
        /// </summary>

        public override void Response()
        {
            if (peliEventti != null)
                Raise();
        }

        public virtual void Raise()
        {

        }

        public override void OnEnableLogic()
        {
            base.OnEnableLogic();
            if (raiseOnEnable)
            {
                Raise();
            }
        }
    }
}