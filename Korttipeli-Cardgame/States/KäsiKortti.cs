using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.GameElements
{
    [CreateAssetMenu(menuName = "Game Elements/KäsiKortti")]
    public class KäsiKortti : GameElementLogic
    {
        public RO.PeliEventit onNykyinenKortti;
        public KorttiVariable currentCard;
        public RO.GameStates.State holdingCard;

        public override void OnClick(KorttiInstanssi inst)
        {
            currentCard.Set(inst);
            Settings.peliSäätäjä.SetState(holdingCard);
            onNykyinenKortti.Raise();
        }

        public override void OnHighlight(KorttiInstanssi inst)
        {

        }
    }
}