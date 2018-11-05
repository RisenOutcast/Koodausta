using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    [CreateAssetMenu(menuName = "Variablet/Transformi")]
    public class TransformiVariable : ScriptableObject
    {
        public Transform value;

        public void Set(Transform v)
        {
            value = v;
        }

        public void Set(TransformiVariable v)
        {
            value = v.value;
        }

        public void Clear()
        {
            value = null;
        }
    }
}
