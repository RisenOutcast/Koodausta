
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RO
{
    public class PeliEventtiListener : MonoBehaviour
    {
        public PeliEventit peliEventti;
        public UnityEvent response;

        /// <summary>
        /// Override this to override the OnEnableLogic()
        /// </summary>
        public virtual void OnEnableLogic()
        {
            if (peliEventti != null)
                peliEventti.Register(this);
        }

        void OnEnable()
        {
            OnEnableLogic();
        }

        /// <summary>
        /// Override this to override the OnDisableLogic()
        /// </summary>
        public virtual void OnDisableLogic()
        {
            if (peliEventti != null)
                peliEventti.UnRegister(this);
        }

        void OnDisable()
        {
            OnDisableLogic();
        }

        public virtual void Response()
        {
            response.Invoke();
        }
    }
}