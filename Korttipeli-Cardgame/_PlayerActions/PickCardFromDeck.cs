using UnityEngine;
using System.Collections;

namespace RO
{
    [CreateAssetMenu(menuName ="Actions/Player Actions/PickCardFromDeck")]
    public class PickCardFromDeck : PlayerAction
    {
        public override void Execute(PlayerHolder player)
        {
            PeliSäätäjä.singleton.PickNewCardFromDeck(player);
            PeliSäätäjä.singleton.ResetCoins(player);
        }

    }
}