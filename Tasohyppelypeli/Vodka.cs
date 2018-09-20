using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Muilutus
{
    public class Vodka : MonoBehaviour
    {

        Animator anim;
        public Transform player;

        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (player)
            {
                float dist = Vector3.Distance(player.position, transform.position);

                if (dist < 7)
                {
                    anim.SetBool("Antaa", true);
                }
                else
                {
                    anim.SetBool("Antaa", false);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "Player")
            {
                anim.SetBool("Anto", true);
            }
        }
    }
}