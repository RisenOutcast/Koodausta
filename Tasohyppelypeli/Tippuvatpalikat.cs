using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Muilutus
{
    public class Tippuvatpalikat : MonoBehaviour
    {

        Animator anim;

        // Use this for initialization
        void Start()
        {
            anim = gameObject.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "Player")
            {
                anim.SetBool("Tippuu", true);
            }
        }
    }
}