using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RO.GameStates
{
    [CreateAssetMenu(menuName = "States/Actions/MouseOverDetection")]
    public class MouseOverDetection : Action
    {
        public override void Execute(float d)
        {

            List<RaycastResult> results = Settings.GetUiObjs();

            IClickable c = null;

            foreach (RaycastResult r in results)
            {
                c = r.gameObject.GetComponentInParent<IClickable>();
                if (c != null)
                {
                    c.OnHighlight();
                    break;
                }
            }
        }
    }
}