using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: M.J.Metsola @RisenOutcast

namespace RO
{
    public class FlyingCollectables : MonoBehaviour
    {
        [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;

        private Rigidbody2D m_Rigidbody2D;
        private Vector3 m_Velocity = Vector3.zero;

        public float speed;

        // Start is called before the first frame update
        void Start()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }


        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Destroy(this.gameObject, 2);
                m_Rigidbody2D.constraints = RigidbodyConstraints2D.None;
            }
        }

        void FixedUpdate()
        {
            Vector3 targetVelocity = new Vector2(speed * 10f, m_Rigidbody2D.velocity.y);
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, movementSmoothing);
        }
    }
}