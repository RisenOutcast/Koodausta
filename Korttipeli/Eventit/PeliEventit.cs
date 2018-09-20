using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    [CreateAssetMenu(menuName = "Peli Eventti")]
    public class PeliEventit : ScriptableObject
    {
        List<PeliEventtiListener> listeners = new List<PeliEventtiListener>();

        public void Register(PeliEventtiListener l)
        {
            listeners.Add(l);
        }

        public void UnRegister(PeliEventtiListener l)
        {
            listeners.Remove(l);
        }

        public void Raise()
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                listeners[i].Response();
            }
        }
    }
}