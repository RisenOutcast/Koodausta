using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RO;

namespace RO
{
    public class AssignTransform : MonoBehaviour
    {
        public TransformiVariable transformVariable;

        private void Awake()
        {
            transformVariable.value = this.transform;
            Destroy(this);
        }

    }
}