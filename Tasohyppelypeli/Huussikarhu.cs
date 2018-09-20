using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RO.Muilutus
{
    public class Huussikarhu : MonoBehaviour
    {

        public Transform player;
        public float speed = 50f;
        Animator anim;
        public Slider Healthbar;
        public GameObject Vihuhealth;
        public float Health = 5;
        private bool kuollu;

        private float CurrentHealth;

        public GameObject Kynnet;

        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>();
            CurrentHealth = Health;
            Healthbar.value = CurrentHealth;
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            Healthbar.value = CurrentHealth;
        }

        // Update is called once per frame
        void Update()
        {

            Healthbar.value = CurrentHealth;


            if (player && kuollu == false)
            {
                float dist = Vector3.Distance(player.position, transform.position);
                float step = speed * Time.deltaTime;

                if (dist < 8 && dist > 2)
                {
                    anim.SetBool("Kävelee", true);
                    transform.position = Vector3.MoveTowards(transform.position, player.position, step);
                }
                else
                {
                    anim.SetBool("Kävelee", false);
                }

                if (dist < 2)
                {
                    anim.SetBool("Hyökkää", true);
                    Kynnet.SetActive(true);
                }
                else
                {
                    anim.SetBool("Hyökkää", false);
                    Kynnet.SetActive(false);
                }

                if (dist < 12)
                {
                    Vihuhealth.SetActive(true);
                }
                else
                {
                    Vihuhealth.SetActive(false);
                }
            }

            if (Healthbar.value < 0.1)
            {
                anim.SetBool("Kuolee", true);
                kuollu = true;
                Destroy(gameObject, 2);
                Vihuhealth.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Whip")
            {
                anim.SetBool("Sattuu", true);
                CurrentHealth -= 1;
            }
            else
            {
                anim.SetBool("Sattuu", false);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Whip")
            {
                anim.SetBool("Sattuu", false);
            }
            else
            {
                anim.SetBool("Sattuu", true);
            }
        }

        public void FixAnimation()
        {
            anim.SetBool("Sattuu", false);
        }
    }
}