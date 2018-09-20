using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    [CreateAssetMenu(menuName = "Vuorot/ResetCurrentPlayerCoinCards")]
    public class ResetCurrentPlayerCoinCards : Phase
    {
        public override bool IsComplete()
        {
            Settings.peliSäätäjä.currentPlayer.MakeAllCoinCardsUsable();
            return true;
        }

        public override void OnEndPhase()
        {
            
        }

        public override void OnStartPhase()
        {
            
        }
    }
}