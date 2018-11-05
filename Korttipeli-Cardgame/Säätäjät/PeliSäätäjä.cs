using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RO.GameStates;

namespace RO
{
    public class PeliSäätäjä : MonoBehaviour
    {
        public PlayerHolder[] all_players;
        public PlayerHolder currentPlayer;
        public CardHolders playerOneHolder;
        public CardHolders otherPlayersHolder;
        public State currentState;
        public GameObject korttiPrefab;

        public int vuoroIndex;
        public Vuoro[] vuorot;
        public RO.PeliEventit onTurnChanged;
        public RO.PeliEventit onPhaseChanged;
        public RO.StringVariable turnText;

        private void Start()
        {
            Settings.peliSäätäjä = this;

            SetupPlayers();

            LuoAlotusKortit();

            turnText.value = vuorot[vuoroIndex].player.username;
            onTurnChanged.Raise();
        }

        void LuoAlotusKortit()
        {
            ResurssiSäätäjä rs = Settings.GetResurssiSäätäjä();

            for (int p = 0; p < all_players.Length; p++)
            {
                for (int i = 0; i < all_players[p].alotusKortit.Length; i++)
                {
                    GameObject go = Instantiate(korttiPrefab) as GameObject;
                    KortinAsentaja a = go.GetComponent<KortinAsentaja>();
                    a.LataaKortti(rs.HaeKorttiInstanssi(all_players[p].alotusKortit[i]));
                    KorttiInstanssi inst = go.GetComponent<KorttiInstanssi>();
                    inst.currentLogic = all_players[p].käsilogiikka;
                    Settings.SetParentForCard(go.transform, all_players[p].currentHolder.käsiGridi.value);
                    all_players[p].kortitKädes.Add(inst);
                }

                Settings.RegisterEvent("Starting cards have been drawn for " + all_players[p].username, all_players[p].playerColor);
            }
        }

        void SetupPlayers()
        {
            foreach (PlayerHolder p in all_players)
            {
                if (p.isHumanPlayer)
                {
                    p.currentHolder = playerOneHolder;
                }
                else
                {
                    p.currentHolder = otherPlayersHolder;
                }
            }
        }

        private void Update()
        {
            bool isComplete = vuorot[vuoroIndex].Execute();

            if (isComplete)
            {

                vuoroIndex++;
                if(vuoroIndex > vuorot.Length - 1)
                {
                    vuoroIndex = 0;
                }

                turnText.value = vuorot[vuoroIndex].player.username;
                onTurnChanged.Raise();
            }

            if(currentState != null)
            currentState.Tick(Time.deltaTime);            
        }

        public void SetState(State state)
        {
            currentState = state;
        }

        public void EndCurrentPhase()
        {
            Settings.RegisterEvent(vuorot[vuoroIndex].name + " finished", currentPlayer.playerColor);

            vuorot[vuoroIndex].EndCurrentPhase();
        }
    }
}
