using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RO
{
    public class ButtonsCooldown : MonoBehaviour
    {

        public bool Move1;
        public bool Move2;
        public bool Move3;
        public bool Move4;

        public GameObject clockIcon;
        public Button Nappi;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Move1)
            {
                if (Settings.peliSäätäjä.all_players[0].Move1CD > 0)
                {
                    clockIcon.SetActive(true);
                    Nappi.interactable = false;
                }
                else
                {
                    clockIcon.SetActive(false);
                }
            }

            if (Move2)
            {
                if (Settings.peliSäätäjä.all_players[0].Move2CD > 0)
                {
                    clockIcon.SetActive(true);
                    Nappi.interactable = false;
                }
                else
                {
                    clockIcon.SetActive(false);
                }
            }

            if (Move3)
            {
                if (Settings.peliSäätäjä.all_players[0].Move3CD > 0)
                {
                    clockIcon.SetActive(true);
                    Nappi.interactable = false;
                }
                else
                {
                    clockIcon.SetActive(false);
                }
            }

            if (Move4)
            {
                if (Settings.peliSäätäjä.all_players[0].Move4CD > 0)
                {
                    clockIcon.SetActive(true);
                    Nappi.interactable = false;
                }
                else
                {
                    clockIcon.SetActive(false);
                }
            }
        }
    }
}