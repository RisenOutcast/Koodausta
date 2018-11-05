using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RO.GameStates
{
    [CreateAssetMenu(menuName = "States/Actions/OnMouseClick")]
    public class OnMouseClick : Action
    {
        public override void Execute(float d)
        {
            if (Input.GetMouseButtonDown(0))
            {

                List<RaycastResult> results = Settings.GetUiObjs();

                foreach (RaycastResult r in results)
                {
                    IClickable c = r.gameObject.GetComponentInParent<IClickable>();
                    if (c != null)
                    {
                        c.OnClick();
                        break;
                    }
                }
            }
        }
    }
}