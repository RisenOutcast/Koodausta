using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: M.J.Metsola @RisenOutcast

namespace RO
{
    public class Buttons : MonoBehaviour
    {
        public Pelaaja player;

        // Start is called before the first frame update
        void Start()
        {
            player.GetComponent<Pelaaja>();
        }

        void Update()
        {
            if (!player)
                player = GameObject.FindWithTag("Player").GetComponent<Pelaaja>();
        }

        // Update is called once per frame
        public void JumpButton()
        {
            player.Jump();
        }

        public void RunTestButton()
        {
            player.isRunning = true;
        }
    }
}