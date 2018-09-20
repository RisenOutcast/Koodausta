using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Muilutus
{
    public class KuoleeYhestä : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Whip")
            {
                Destroy(gameObject);
            }
        }
    }
}