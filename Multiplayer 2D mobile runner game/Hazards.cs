using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: M.J.Metsola @RisenOutcast

namespace RO
{
    public class Hazards : MonoBehaviour
    {
        private Rigidbody2D m_Rigidbody2D;

        // Start is called before the first frame update
        void Start()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Pelisäätäjä.instance.isOverlord)
            {
                for (var i = 0; i < Input.touchCount; ++i)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
                        if (hitInfo)
                        {
                            Debug.Log(hitInfo.transform.gameObject.name);
                            DropApple();
                        }
                    }
                }
            }
        }

        void UserInput()
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                var touch = Input.touches[i];
                if (touch.position.x < Screen.width / 2)
                {
                    Debug.Log("Left click");
                    DropApple();
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    Debug.Log("Right click");
                }

                Ray raycast = Camera.main.ScreenPointToRay(Input.touches[i].position);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {
                    if (raycastHit.collider.CompareTag("JumpButton"))
                    {
                        //Jump();
                    }
                }
            }
        }

        void DropApple()
        {
            m_Rigidbody2D.constraints = RigidbodyConstraints2D.None;
        }
    }
}