using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RO.Muilutus
{
    public class PelaajaMuilutus : MonoBehaviour
    {

        #region

        public float maxSpeed = 3;
        public float speed = 50f;
        public float jumpPower = 150f;
        public Slider Healthbar;
        public float Health = 100;

        public GameObject WhipCollider;
        public Transform WhipColliderSpawnPointRight;
        public Transform WhipColliderSpawnPointLeft;

        private float CurrentHealth;

        public bool Attacking;
        public bool FacingRight;

        public bool isGrounded;
        Animator anim;
        private Rigidbody2D rb2d;
        private SpriteRenderer rend;

        #endregion

        // Use this for initialization
        void Start()
        {
            rb2d = gameObject.GetComponent<Rigidbody2D>();
            rend = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            CurrentHealth = Health;
            Healthbar.value = CurrentHealth;
            Attacking = false;
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            Healthbar.value = CurrentHealth;
        }

        void OnCollisionEnter2D(Collision2D other)
        {

            if (other.collider.tag == "Ground")
            {
                isGrounded = true;
            }
        }
        void OnCollisionStay2D(Collision2D other)
        {

            if (other.collider.tag == "Ground")
            {
                isGrounded = true;
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Vodka")
            {
                Healthbar.value = 100;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "Hylsy")
            {
                Healthbar.value -= 1;
                anim.SetBool("Damage", true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Hylsy")
            {
                anim.SetBool("Damage", false);
            }
        }

        void OnCollisionExit2D(Collision2D other)
        {

            if (other.collider.tag == "Ground")
            {
                isGrounded = false;
            }
        }

        void Update()
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
            }

            if (Input.GetButton("Fire3"))
            {
                maxSpeed = 6;
            }
            else
            {
                maxSpeed = 3;
            }

            if (Input.GetAxis("Horizontal") < -0.1f || Input.GetAxis("Horizontal") > 0.1f)
            {
                anim.SetBool("Juoksee", true);
            }
            else
            {
                anim.SetBool("Juoksee", false);
            }

            if (Input.GetButtonDown("Fire3"))
            {
                anim.SetBool("JuokseeKovempaa", true);
            }

            if (Input.GetButtonUp("Fire3"))
            {
                anim.SetBool("JuokseeKovempaa", false);
            }

            if (Input.GetButton("Fire4"))
            {
                anim.SetBool("Isku", true);
            }
            else
            {
                anim.SetBool("Isku", false);
            }

            if (isGrounded)
            {
                anim.SetBool("Hyppää", false);
            }
            else
            {
                anim.SetBool("Hyppää", true);
            }

            if (Healthbar.value < 0.1)
            {
                anim.SetBool("KuoliSaatana", true);
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Attacking == false)
            {
                float h = Input.GetAxis("Horizontal");

                rb2d.AddForce((Vector2.right * speed) * h);

                if (rb2d.velocity.x > maxSpeed)
                {
                    rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
                }

                if (rb2d.velocity.x < -maxSpeed)
                {
                    rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
                }

                if (Input.GetAxis("Horizontal") < -0.1f)
                {
                    rend.flipX = true;
                    FacingRight = false;
                }

                if (Input.GetAxis("Horizontal") > 0.1f)
                {
                    rend.flipX = false;
                    FacingRight = true;
                }
            }
        }

        public void FixAnimation()
        {
            anim.SetBool("Damage", false);
        }

        public void SpawnWhipCollider()
        {
            if (FacingRight == true)
            {
                Instantiate(WhipCollider, WhipColliderSpawnPointRight.position, Quaternion.identity);
            }
            else
            {
                Instantiate(WhipCollider, WhipColliderSpawnPointLeft.position, Quaternion.identity);
            }
        }

        public void Animaatioalkaa()
        {
            Attacking = true;
        }

        public void Animaatioloppuu()
        {
            Attacking = false;
        }
    }
}