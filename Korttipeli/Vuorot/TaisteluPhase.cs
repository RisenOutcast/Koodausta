using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    [CreateAssetMenu(menuName = "Vuorot/PelaajaTaisteluPhase")]
    public class TaisteluPhase : Phase
    {
        public override bool IsComplete()
        {
            if (forceExit)
            {
                forceExit = false;

                return true;
            }

            return false;
        }

        public override void OnEndPhase()
        {
            if (isInit)
            {
                Settings.peliSäätäjä.SetState(null);
                isInit = false;
            }
        }

        public override void OnStartPhase()
        {
            if (!isInit)
            {
                Settings.peliSäätäjä.SetState(null);
                Settings.peliSäätäjä.onPhaseChanged.Raise();
                isInit = true;
            }
        }
    }
}