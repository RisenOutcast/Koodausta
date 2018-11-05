using UnityEngine;
using System.Collections;

public class KortitSeuraa : MonoBehaviour
{

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject Seurattava;
    public Vector3 offset;
    Vector3 targetPos;

    void Start()
    {
        targetPos = transform.position;
    }


    void Update()
    {
        if (Seurattava)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = Seurattava.transform.position.z;

            Vector3 targetDirection = (Seurattava.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 50f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.35f);

        }
    }
}