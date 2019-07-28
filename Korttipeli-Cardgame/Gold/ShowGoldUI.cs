using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    public class ShowGoldUI : MonoBehaviour
    {

        public GameObject[] Koliket;
        public int CoinsLeft;
        public int showCoins;
        public int Used;

        // Use this for initialization
        void Start()
        {
            Koliket = GameObject.FindGameObjectsWithTag("Gold");

            for (int i = 0; i < Koliket.Length; i++)
            {
                Koliket[i].SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            CoinsLeft = Settings.peliSäätäjä.all_players[0].Kulta;

            if (CoinsLeft == 10)
            {
                Koliket[0].SetActive(true);
                Koliket[1].SetActive(true);
                Koliket[2].SetActive(true);
                Koliket[3].SetActive(true);
                Koliket[4].SetActive(true);
                Koliket[5].SetActive(true);
                Koliket[6].SetActive(true);
                Koliket[7].SetActive(true);
                Koliket[8].SetActive(true);
                Koliket[9].SetActive(true);
            }

            if (CoinsLeft == 9)
            {
                Koliket[0].SetActive(true);
                Koliket[1].SetActive(true);
                Koliket[2].SetActive(true);
                Koliket[3].SetActive(true);
                Koliket[4].SetActive(true);
                Koliket[5].SetActive(true);
                Koliket[6].SetActive(true);
                Koliket[7].SetActive(true);
                Koliket[8].SetActive(true);
                Koliket[9].SetActive(false);
            }

            if (CoinsLeft == 8)
            {
                Koliket[0].SetActive(true);
                Koliket[1].SetActive(true);
                Koliket[2].SetActive(true);
                Koliket[3].SetActive(true);
                Koliket[4].SetActive(true);
                Koliket[5].SetActive(true);
                Koliket[6].SetActive(true);
                Koliket[7].SetActive(true);
                Koliket[8].SetActive(false);
                Koliket[9].SetActive(false);
            }

            if (CoinsLeft == 7)
            {
                Koliket[0].SetActive(true);
                Koliket[1].SetActive(true);
                Koliket[2].SetActive(true);
                Koliket[3].SetActive(true);
                Koliket[4].SetActive(true);
                Koliket[5].SetActive(true);
                Koliket[6].SetActive(true);
                Koliket[7].SetActive(false);
                Koliket[8].SetActive(false);
                Koliket[9].SetActive(false);
            }

            if (CoinsLeft == 6)
            {
                Koliket[0].SetActive(true);
                Koliket[1].SetActive(true);
                Koliket[2].SetActive(true);
                Koliket[3].SetActive(true);
                Koliket[4].SetActive(true);
                Koliket[5].SetActive(true);
                Koliket[6].SetActive(false);
                Koliket[7].SetActive(false);
                Koliket[8].SetActive(false);
                Koliket[9].SetActive(false);
            }

            if (CoinsLeft == 5)
            {
                Koliket[0].SetActive(true);
                Koliket[1].SetActive(true);
                Koliket[2].SetActive(true);
                Koliket[3].SetActive(true);
                Koliket[4].SetActive(true);
                Koliket[5].SetActive(false);
                Koliket[6].SetActive(false);
                Koliket[7].SetActive(false);
                Koliket[8].SetActive(false);
                Koliket[9].SetActive(false);
            }

            if (CoinsLeft == 4)
            {
                Koliket[0].SetActive(true);
                Koliket[1].SetActive(true);
                Koliket[2].SetActive(true);
                Koliket[3].SetActive(true);
                Koliket[4].SetActive(false);
                Koliket[5].SetActive(false);
                Koliket[6].SetActive(false);
                Koliket[7].SetActive(false);
                Koliket[8].SetActive(false);
                Koliket[9].SetActive(false);
            }

            if (CoinsLeft == 3)
            {
                Koliket[0].SetActive(true);
                Koliket[1].SetActive(true);
                Koliket[2].SetActive(true);
                Koliket[3].SetActive(false);
                Koliket[4].SetActive(false);
                Koliket[5].SetActive(false);
                Koliket[6].SetActive(false);
                Koliket[7].SetActive(false);
                Koliket[8].SetActive(false);
                Koliket[9].SetActive(false);
            }

            if (CoinsLeft == 2)
            {
                Koliket[0].SetActive(true);
                Koliket[1].SetActive(true);
                Koliket[2].SetActive(false);
                Koliket[3].SetActive(false);
                Koliket[4].SetActive(false);
                Koliket[5].SetActive(false);
                Koliket[6].SetActive(false);
                Koliket[7].SetActive(false);
                Koliket[8].SetActive(false);
                Koliket[9].SetActive(false);
            }

            if (CoinsLeft == 1)
            {
                Koliket[0].SetActive(true);
                Koliket[1].SetActive(false);
                Koliket[2].SetActive(false);
                Koliket[3].SetActive(false);
                Koliket[4].SetActive(false);
                Koliket[5].SetActive(false);
                Koliket[6].SetActive(false);
                Koliket[7].SetActive(false);
                Koliket[8].SetActive(false);
                Koliket[9].SetActive(false);
            }

            if (CoinsLeft == 0)
            {
                Koliket[0].SetActive(false);
                Koliket[1].SetActive(false);
                Koliket[2].SetActive(false);
                Koliket[3].SetActive(false);
                Koliket[4].SetActive(false);
                Koliket[5].SetActive(false);
                Koliket[6].SetActive(false);
                Koliket[7].SetActive(false);
                Koliket[8].SetActive(false);
                Koliket[9].SetActive(false);
            }
        }
    }
}