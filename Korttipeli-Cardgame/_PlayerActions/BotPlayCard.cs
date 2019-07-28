using UnityEngine;
using System.Collections;

namespace RO
{
    [CreateAssetMenu(menuName = "Actions/Player Actions/BotPlayCard")]
    public class BotPlayCard : PlayerAction
    {
        public override void Execute(PlayerHolder player)
        {
            PeliSäätäjä.singleton.BotPlayEveryCard(player);
        }

    }
}
