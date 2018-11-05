using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RO;
using UnityEngine.UI;
using TMPro;

namespace RO.UI {
    public class UpdateTextFromPhase : UIPropertyUpdater
    {
        public PhaseVariable currentPhase;
        public TMP_Text targetText;

        public override void Raise()
        {
            targetText.text = currentPhase.value.phaseName;
        }
    }
}