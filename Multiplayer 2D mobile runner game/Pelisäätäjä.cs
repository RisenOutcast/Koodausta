using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//Author: M.J.Metsola @RisenOutcast

namespace RO
{
    public class Pelisäätäjä : MonoBehaviour
    {
        public static Pelisäätäjä instance = null;

        public Player Runner;
        public Player Overlord;

        public Pelaaja PlayerScript;
        public Lintu LintuScript;


        public bool isOverlord;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(this);
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}