using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RO.GameStates
{
    [CreateAssetMenu(menuName = "States/Actions/MouseHoldWithCard")]
    public class MouseHoldWithCard : Action
    {
        public KorttiVariable nykyinenKortti;
        public State playerControlState;
        public RO.PeliEventit onPlayerControlState;

        public override void Execute(float d)
        {
            bool mouseIsDown = Input.GetMouseButton(0);

            if (!mouseIsDown)
            {
                List<RaycastResult> results = Settings.GetUiObjs();

                foreach (RaycastResult r in results)
                {
                    //Check for dropable areas
                    GameElements.Alue a = r.gameObject.GetComponentInParent<GameElements.Alue>();
                    if (a != null)
                    {
                        a.OnDrop();
                        break;
                    }
                }

                nykyinenKortti.value.gameObject.SetActive(true);
                nykyinenKortti.value = null;

                Settings.peliSäätäjä.SetState(playerControlState);
                onPlayerControlState.Raise();
                return;
            }
        }
    }
}