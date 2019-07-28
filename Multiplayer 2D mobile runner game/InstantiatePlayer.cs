using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    public class InstantiatePlayer : MonoBehaviourPunCallbacks
    {

        public GameObject Pelaaja;
        public GameObject Lintu;

        // Start is called before the first frame update
        void Start()
        {
            if (!Pelisäätäjä.instance.isOverlord)
            {
                PhotonNetwork.Instantiate("Pelaaja", Pelaaja.transform.position, Pelaaja.transform.rotation, 0);
            }
            else
            {
                PhotonNetwork.Instantiate("Lintu", Lintu.transform.position, Lintu.transform.rotation, 0);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}