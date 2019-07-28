using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO {
    public class ShowMinions : MonoBehaviour {

        public int PlayerID;

        public GameObject Phas1;
        public GameObject Phas2;
        public GameObject Phas3;
        public GameObject Phas4;

        public GameObject Abas1;
        public GameObject Abas2;
        public GameObject Abas3;
        public GameObject Abas4;

        public GameObject Tygo1;
        public GameObject Tygo2;
        public GameObject Tygo3;
        public GameObject Tygo4;

        // Use this for initialization
        void Start() {
            Phas1.SetActive(false);
            Phas2.SetActive(false);
            Phas3.SetActive(false);
            Phas4.SetActive(false);

            Abas1.SetActive(false);
            Abas2.SetActive(false);
            Abas3.SetActive(false);
            Abas4.SetActive(false);

            Tygo1.SetActive(false);
            Tygo2.SetActive(false);
            Tygo3.SetActive(false);
            Tygo4.SetActive(false);
        }

        // Update is called once per frame
        void Update() {
            if (Settings.peliSäätäjä.all_players[PlayerID].hasActiveMinions == true)
            {
                //Activate Minions
                if (Settings.peliSäätäjä.all_players[PlayerID].PhasAmount > 0 && !Phas1.activeSelf && !Phas2.activeSelf && !Phas3.activeSelf && !Phas4.activeSelf)
                {
                    ActivatePhas();
                }

                if (Settings.peliSäätäjä.all_players[PlayerID].AbasAmount > 0 && !Abas1.activeSelf && !Abas2.activeSelf && !Abas3.activeSelf && !Abas4.activeSelf)
                {
                    ActivateAbas();
                }

                if (Settings.peliSäätäjä.all_players[PlayerID].TygoAmount > 0 && !Tygo1.activeSelf && !Tygo2.activeSelf && !Tygo3.activeSelf && !Tygo4.activeSelf)
                {
                    ActivateTygo();
                }

            }
    
        }

        public void ActivatePhas()
        {
            Phas1.SetActive(true);
            Phas2.SetActive(true);
            Phas3.SetActive(true);
            Phas4.SetActive(true);
        }

        public void ActivateAbas()
        {
            Abas1.SetActive(true);
            Abas2.SetActive(true);
            Abas3.SetActive(true);
            Abas4.SetActive(true);
        }

        public void ActivateTygo()
        {
            Tygo1.SetActive(true);
            Tygo2.SetActive(true);
            Tygo3.SetActive(true);
            Tygo4.SetActive(true);
        }

    }
}