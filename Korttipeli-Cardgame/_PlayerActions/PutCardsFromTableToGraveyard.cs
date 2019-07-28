using UnityEngine;
using System.Collections;

namespace RO
{
    [CreateAssetMenu(menuName = "Actions/Player Actions/PutCardsFromTableToGraveyard")]
    public class PutCardsFromTableToGraveyard : PlayerAction
    {
        public override void Execute(PlayerHolder player)
        {
            if (player.ResetCardTurn == false)
            {
                PeliSäätäjä.singleton.UsedCardsInGraveyard(player);
            }
        }

    }
}
