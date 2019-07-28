using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    [CreateAssetMenu(menuName = "Vuorot/PelaajaControlliPhase")]
    public class PelaajaControlliPhase : Phase
    {
        public GameStates.State pelaajaControlliState;
        public GameStates.State Nothing;

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
                Settings.peliSäätäjä.SetState(pelaajaControlliState);
                Settings.peliSäätäjä.onPhaseChanged.Raise();
                Settings.peliSäätäjä.MainCamera.SetActive(true);
                Settings.peliSäätäjä.BattleCamera.SetActive(false);
                Settings.peliSäätäjä.MainCanvas.SetActive(true);
                Settings.peliSäätäjä.BattleCanvas.SetActive(false);
                isInit = true;
            }
        }
    }
}