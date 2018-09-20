using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Muilutus
{
    public class Whip : MonoBehaviour
    {

        Animator anim;

        public float interpVelocity;
        public float minDistance;
        public float followDistance;
        public GameObject Pelaaja;
        public Vector3 offset;
        Vector3 targetPos;

        public PelaajaMuilutus Hahmo;

        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>();
            targetPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire4"))
            {
                anim.SetBool("Collider", true);
            }

            if (Input.GetButtonUp("Fire4"))
            {
                anim.SetBool("Collider", false);
            }
        }

        public void Animaatioalkaa()
        {
            Hahmo.Attacking = true;
        }

        public void Animaatioloppuu()
        {
            Hahmo.Attacking = false;
        }
    }
}