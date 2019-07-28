using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    [CreateAssetMenu(menuName = "Actions/Player Actions/MakeButtonsClickable")]
    public class MakeButtonsClickable : PlayerAction
    {
        public override void Execute(PlayerHolder player)
        {
            if (Settings.peliSäätäjä.all_players[0].Move1CD == 0)
            {
                Settings.peliSäätäjä.attackButtons.Buttons[0].interactable = true;
            }

            if (Settings.peliSäätäjä.all_players[0].Move2CD == 0)
            {
                Settings.peliSäätäjä.attackButtons.Buttons[1].interactable = true;
            }

            if (Settings.peliSäätäjä.all_players[0].Move3CD == 0)
            {
                Settings.peliSäätäjä.attackButtons.Buttons[2].interactable = true;
            }

            if (Settings.peliSäätäjä.all_players[0].Move4CD == 0)
            {
                Settings.peliSäätäjä.attackButtons.Buttons[3].interactable = true;
            }
        }

    }
}