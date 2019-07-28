using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    public class DecoyLintu : MonoBehaviour
    {
        public GameObject lintu;

        public float interpVelocity;
        public float minDistance;
        public float followDistance;
        Vector3 targetPos;
        Vector3 finalPos;

        // Start is called before the first frame update
        void Start()
        {
            lintu = Pelisäätäjä.instance.LintuScript.gameObject;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            FollowPlayer();
        }

        private void FollowPlayer()
        {
            if (lintu.transform.position.x > transform.position.x)
            {
                Vector3 posNoZ = transform.position;
                posNoZ.z = lintu.transform.position.z;

                Vector3 targetDirection = (lintu.transform.position - posNoZ);

                interpVelocity = targetDirection.magnitude * 15f;

                targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.fixedDeltaTime);

                transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.7F);
            }
        }
    }
}