using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    [CreateAssetMenu(menuName = "Vuorot/ClientEmptyPhase")]
    public class ClientEmptyPhase : Phase
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

        }

        public override void OnStartPhase()
        {
            if (!isInit)
            {
                Settings.peliSäätäjä.MainCamera.SetActive(true);
                Settings.peliSäätäjä.BattleCamera.SetActive(false);
                Settings.peliSäätäjä.MainCanvas.SetActive(true);
                Settings.peliSäätäjä.BattleCanvas.SetActive(false);
                isInit = true;
            }
        }
    }
}
