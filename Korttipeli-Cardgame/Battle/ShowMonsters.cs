using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO {
    public class ShowMonsters : MonoBehaviour {

        public int PlayerID;
        public GameObject Grontto;
        public GameObject Angira;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            if (Settings.peliSäätäjä.all_players[PlayerID].Grontto == true)
            {
                Angira.SetActive(false);
                Grontto.SetActive(true);
            }
            else
            {
                Angira.SetActive(true);
                Grontto.SetActive(false);
            }
        }
    }
}