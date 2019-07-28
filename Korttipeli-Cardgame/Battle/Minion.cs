using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    public class Minion : MonoBehaviour
    {
        public int PlayerID;
        public int MinionNumber;
        public bool Phas;
        public bool Abas;
        public bool Tygo;

        public int Healthleft = 1;

        public bool isDead;

        public int Test;

        Animator anim;

        // Use this for initialization
        void Start()
        {
            anim = gameObject.GetComponent<Animator>();
            anim.SetBool("Spawn", true);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Test = Settings.peliSäätäjä.all_players[PlayerID].PhasAmount;

            if (MinionNumber == 1)
            {
                Healthleft = Settings.peliSäätäjä.all_players[PlayerID].Minion1Health;
            }

            if (MinionNumber == 2)
            {
                Healthleft = Settings.peliSäätäjä.all_players[PlayerID].Minion2Health;
            }

            if (MinionNumber == 3)
            {
                Healthleft = Settings.peliSäätäjä.all_players[PlayerID].Minion3Health;
            }

            if (MinionNumber == 4)
            {
                Healthleft = Settings.peliSäätäjä.all_players[PlayerID].Minion4Health;
            }

            if (Healthleft < 1)
            {
                if (Healthleft < 0)
                {
                    if (MinionNumber == 1)
                        Settings.peliSäätäjä.all_players[PlayerID].Minion1Health = 0;

                    if (MinionNumber == 2)
                        Settings.peliSäätäjä.all_players[PlayerID].Minion2Health = 0;

                    if (MinionNumber == 3)
                        Settings.peliSäätäjä.all_players[PlayerID].Minion3Health = 0;

                    if (MinionNumber == 4)
                        Settings.peliSäätäjä.all_players[PlayerID].Minion4Health = 0;
                }
                isDead = true;
                anim.SetBool("Death", true);
                isDead = false;
            }
        }

        void DecreaceMinionAmount()
        {
            if (Phas == true)
            {
                Settings.peliSäätäjä.all_players[PlayerID].PhasAmount -= 1;
            }
            if (Abas == true)
            {
                Settings.peliSäätäjä.all_players[PlayerID].AbasAmount -= 1;
            }
            if (Tygo == true)
            {
                Settings.peliSäätäjä.all_players[PlayerID].TygoAmount -= 1;
            }
        }

        public void Spawn()
        {
            anim.SetBool("Spawn", false);
        }

        public void Death()
        {
            DecreaceMinionAmount();
            gameObject.SetActive(false);
        }

        public void Attack()
        {
            anim.SetBool("Attack", false);
        }

    }
}