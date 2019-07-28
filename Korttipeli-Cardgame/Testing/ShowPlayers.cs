using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    public class ShowPlayers : MonoBehaviour
    {

        public string CurrentPlayer;
        public string Player1;
        public string Player2;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            CurrentPlayer = Settings.peliSäätäjä.currentPlayer.ToString();
            Player1 = Settings.peliSäätäjä.all_players[0].ToString();
            Player2 = Settings.peliSäätäjä.all_players[1].ToString();
        }
    }
}