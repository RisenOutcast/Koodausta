using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//Author: M.J.Metsola @RisenOutcast

namespace RO
{
    public class Lintu : MonoBehaviourPun, IPunObservable
    {
        [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;

        private Rigidbody2D m_Rigidbody2D;
        private Vector3 m_Velocity = Vector3.zero;

        public float distanceToPlayer;
        public Transform player;

        public float speed;
        public int Points;

        public int startingDistance = 80;
        public bool distanceGained;

        CameraFollow cameraFollowi;

        public PhotonView _photonView;

        public GameObject Decoy;

        //Values that will be synced over network
        Vector3 latestPos;
        Quaternion latestRot;

        // Start is called before the first frame update
        IEnumerator Start()
        {
            yield return new WaitForSeconds(2f);
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            distanceGained = false;
            cameraFollowi = Camera.main.GetComponent<CameraFollow>();
            Pelisäätäjä.instance.LintuScript = this;
            player = Pelisäätäjä.instance.PlayerScript.gameObject.GetComponent<Transform>();

            if (!_photonView.IsMine)
            {
                Decoy = Instantiate(Decoy, transform.position, transform.rotation);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            distanceToPlayer = Vector3.Distance(player.position, transform.position);

            if (distanceToPlayer < startingDistance && !distanceGained && cameraFollowi.Follow)
                speed = 10;

            if (distanceToPlayer >= startingDistance)
            {
                distanceGained = true;
                speed = 0.6F;
            }

            if (distanceToPlayer <= 3.5F)
            {
                speed = 1F;
            } else if (distanceToPlayer > 8 && distanceGained)
            {
                speed = 0.6F;
            }

            if (!_photonView.IsMine)
            {
                //Update remote player (smooth this, this looks good, at the cost of some accuracy)
                transform.position = Vector3.Lerp(transform.position, latestPos, Time.deltaTime * 8);
                transform.rotation = Quaternion.Lerp(transform.rotation, latestRot, Time.deltaTime * 8);
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Destroy(this.gameObject, 2);
                m_Rigidbody2D.constraints = RigidbodyConstraints2D.None;
                //Make win/lose condition
            }
        }

        void FixedUpdate()
        {
            if (_photonView.IsMine)
            {
                Vector3 targetVelocity = new Vector2(speed * 10f, m_Rigidbody2D.velocity.y);
                m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, movementSmoothing);
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
            }
            else
            {
                //Network player, receive data
                latestPos = (Vector3)stream.ReceiveNext() * 1.009F;
                latestRot = (Quaternion)stream.ReceiveNext();
                Points = (int)stream.ReceiveNext();
            }
        }
    }
}