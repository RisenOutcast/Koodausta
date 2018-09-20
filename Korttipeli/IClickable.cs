using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    public interface IClickable
    {
        void OnClick();

        void OnHighlight();
    }
}