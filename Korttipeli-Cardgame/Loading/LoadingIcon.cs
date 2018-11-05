using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Loading
{
    public class LoadingIcon : MonoBehaviour
    {

        public bool LoadingIsHappening;
        public float speed = -121;

        private Animator anim;

        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (LoadingIsHappening == true)
            {
                transform.Rotate(0, 0, speed * Time.deltaTime);
                anim.SetBool("LoadingisHappening",true);
            }
            else
            {
                transform.Rotate(0, 0, 0);
                anim.SetBool("LoadingisHappening", false);
            }
            
        }
    }
}