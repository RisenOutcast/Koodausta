using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    [CreateAssetMenu(menuName = "Actions/Player Actions/YourTurnText")]
    public class YourTurnText : PlayerAction
    {
        public override void Execute(PlayerHolder player)
        {
            PeliSäätäjä.singleton.ActivateYourTurnText();
        }

    }
}