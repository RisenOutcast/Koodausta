using UnityEngine;
using System.Collections;

namespace RO
{
    [CreateAssetMenu(menuName = "Actions/Player Actions/ResetCardTurn")]
    public class ResetCardTurn : PlayerAction
    {
        public override void Execute(PlayerHolder player)
        {
            player.ResetCardTurn = false;
        }

    }
}