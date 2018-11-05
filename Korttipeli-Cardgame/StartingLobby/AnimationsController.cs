using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Menus
{
    public class AnimationsController : MonoBehaviour
    {

        public GameObject Camera;
        public GameObject LoginCanvas;

        private Animator CamAnim;
        private Animator LoginCanvasAnim;

        public bool LoginSuccesfullTEST;

        void Awake()
        {
            CamAnim = Camera.GetComponent<Animator>();
            LoginCanvasAnim = LoginCanvas.GetComponent<Animator>();
        }

        void Start()
        {
            CamAnim.SetBool("loginSuccesful", false);
            LoginCanvasAnim.SetBool("LoginSuccesful", false);
        }

        // Update is called once per frame
        void Update()
        {
            if(LoginSuccesfullTEST == true)
            {
                LoginCanvasAnim.SetBool("LoginSuccesful", true);
            }
        }

        public void CanvasHasDisappeared()
        {
            CamAnim.SetBool("loginSuccesful", true);
        }
    }
}