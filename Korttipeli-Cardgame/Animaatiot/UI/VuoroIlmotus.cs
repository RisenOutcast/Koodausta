using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    public class VuoroIlmotus : MonoBehaviour
    {
        public GameObject YourTurnIlmotus;

        public void FinishAnimation()
        {
            YourTurnIlmotus.SetActive(false);
        }
        
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}