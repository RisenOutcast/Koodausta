using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: M.J.Metsola @RisenOutcast

namespace RO
{
    public class Pelaaja : MonoBehaviourPun, IPunObservable
    {
        #region Moving

        [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;// How much to smooth out the movement
        [SerializeField] private Collider2D crouchDisableCollider;// A collider that will be disabled when crouching

        const float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
        private Rigidbody2D m_Rigidbody2D;
        private Vector3 m_Velocity = Vector3.zero;

        public float speed = 150f;
        public float jumpPower;

        Animator anim;
        #endregion
        //from here towards
        public bool isRunning;
        public bool isGrounded;
        public bool stuck;
        public bool isDead;

        public int Health;
        public int Points;

        public int startingHealth;

        CameraFollow cameraFollowi;
        public GameObject alkuTeksti;

        public PhotonView _photonView;

        //Values that will be synced over network
        Vector3 latestPos;
        Quaternion latestRot;

        //Values for decoy following smoothly
        public GameObject Decoy;

        // Start is called before the first frame update
        void Start()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            cameraFollowi = Camera.main.GetComponent<CameraFollow>();

            Pelisäätäjä.instance.PlayerScript = this;

            Health = startingHealth;

            if(alkuTeksti == null)
                alkuTeksti = GameObject.FindWithTag("TapHold").gameObject;

            if (!_photonView.IsMine)
            {
                Decoy = Instantiate(Decoy, transform.position, transform.rotation);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        private void Update()
        {
            if (_photonView.IsMine)
            {
                UserInput();
            }
            else
            {
                //Update this player (smooth this, this looks good, at the cost of some accuracy)
                transform.position = Vector3.Lerp(transform.position, latestPos, Time.deltaTime * 8);
                transform.rotation = Quaternion.Lerp(transform.rotation, latestRot, Time.deltaTime * 8);
            }

            if (alkuTeksti == null)
                alkuTeksti = GameObject.FindWithTag("TapHold").gameObject;
        }

        void OnCollisionEnter2D(Collision2D other)
        {

            if (other.collider.tag == "Ground")
            {
                isGrounded = true;
            }

            if (other.collider.tag == "Omena")
            {
                Health -= 1;
                Points -= 100;
            }
        }

        void OnCollisionExit2D(Collision2D other)
        {
            if (other.collider.tag == "Ground")
            {
                isGrounded = false;
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Alku")
            {
                cameraFollowi.Follow = true;
            }
            if (collision.tag == "Collectible")
            {
                Points += 100;
            }
            if (collision.tag == "Off-limit")
            {
                isDead = true;
            }
            if (collision.tag == "Omena")
            {
                Points += 100;
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (isRunning == true)
            {
                Vector3 targetVelocity = new Vector2(speed * 10f, m_Rigidbody2D.velocity.y);
                m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, movementSmoothing);
            }
        }

        public void Jump()
        {
            if (isGrounded)
            {
                m_Rigidbody2D.AddForce(Vector2.up * jumpPower);
                Debug.Log("Jump called");
            }
        }

        private void UserInput()
        {
            //if (Application.platform == RuntimePlatform.Android) if you want to disable touch controls on PC.

            for (int i = 0; i < Input.touchCount; i++)
            {
                var touch = Input.touches[i];
                if (touch.position.x < Screen.width / 2)
                {
                    Debug.Log("Left click");
                    if (touch.phase == TouchPhase.Began && !stuck)
                    {
                        isRunning = true;
                        if (alkuTeksti.activeSelf)
                            alkuTeksti.SetActive(false);
                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                        isRunning = false;
                    }
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    Debug.Log("Right click");
                    if (touch.phase == TouchPhase.Began)
                    {
                        //Jump();
                    }
                }
            }
        }


        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                //We own this player: send the others our data
                stream.SendNext(transform.position);
                stream.SendNext(transform.rotation);
                stream.SendNext(Points);
                stream.SendNext(Health);
            }
            else
            {
                //Network player, receive data
                latestPos = (Vector3)stream.ReceiveNext();
                latestRot = (Quaternion)stream.ReceiveNext();

                float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
                latestPos += (Vector3)m_Rigidbody2D.velocity * lag;

                Points = (int)stream.ReceiveNext();
                Health = (int)stream.ReceiveNext();
            }
        }
    }
}