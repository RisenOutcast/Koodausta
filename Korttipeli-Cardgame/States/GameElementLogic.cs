using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.GameElements
{
    public abstract class GameElementLogic : ScriptableObject
    {
        public abstract void OnClick(KorttiInstanssi inst);

        public abstract void OnHighlight(KorttiInstanssi inst);
    }
}