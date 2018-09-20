using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Muilutus
{
    public class Huussi : MonoBehaviour
    {

        Animator anim;
        int osumat;
        public GameObject Karhu;

        // Use this for initialization
        void Start()
        {
            anim = gameObject.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            anim.SetInteger("Osuu", osumat);

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("tyhjähuussi"))
            {
                if (Karhu != null)
                {
                    Karhu.SetActive(true);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Whip")
            {
                osumat += 1;
            }
        }
    }
}