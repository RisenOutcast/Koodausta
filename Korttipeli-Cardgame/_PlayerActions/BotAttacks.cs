using UnityEngine;
using System.Collections;

namespace RO
{
    [CreateAssetMenu(menuName = "Actions/Player Actions/BotAttacks")]
    public class BotAttacks : PlayerAction
    {
        public override void Execute(PlayerHolder player)
        {
            PeliSäätäjä.singleton.BotChoocesAttack(player);
        }

    }
}
