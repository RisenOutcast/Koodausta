using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    [CreateAssetMenu(menuName = "Vuorot/PelaajaTaisteluPhase")]
    public class TaisteluPhase : Phase
    {
        public GameStates.State TaisteluStateControl;

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
                Settings.peliSäätäjä.SetState(TaisteluStateControl);
                Settings.peliSäätäjä.onPhaseChanged.Raise();
                Debug.Log("Battle phase begins!");
                Settings.peliSäätäjä.MainCamera.SetActive(false);
                Settings.peliSäätäjä.BattleCamera.SetActive(true);
                Settings.peliSäätäjä.MainCanvas.SetActive(false);
                Settings.peliSäätäjä.BattleCanvas.SetActive(true);
                isInit = true;
            }
        }
    }
}