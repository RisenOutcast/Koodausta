using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.GameElements
{
    [CreateAssetMenu(menuName = "Game Elements/PöytäKortti")]
    public class PöytäKortti : GameElementLogic
    {
        public override void OnClick(KorttiInstanssi inst)
        {
            Debug.Log("Card on table");
        }

        public override void OnHighlight(KorttiInstanssi inst)
        {

        }
    }
}