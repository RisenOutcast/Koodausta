using UnityEngine;
using System.Collections;

namespace RO
{
    public abstract class PlayerAction : ScriptableObject
    {
        public abstract void Execute(PlayerHolder player);
    }
}