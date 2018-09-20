using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Muilutus
{
    public class ViisHelaajakuolee : MonoBehaviour
    {

        private float health = 5;


        // Use this for initialization
        void Start()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Whip")
            {
                health -= 1;
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}