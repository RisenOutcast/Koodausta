using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RO.GameStates;

namespace RO
{
    public class PeliSäätäjä : MonoBehaviour
    {
        public PlayerHolder[] all_players;
        public PlayerHolder currentPlayer;

        public PlayerHolder localPlayer;
        public PlayerHolder clientPlayer;
        public CardHolders playerOneHolder;
        public CardHolders otherPlayersHolder;

        public State currentState;
        public GameObject korttiPrefab;

        public bool botGame = false;
        bool isInit = false;

        public Mestarisäätäjä Mestari;

        public int vuoroIndex;
        public Vuoro[] vuorot;
        public Vuoro[] vuorotNormaali;
        public Vuoro[] vuorotReverse;
        public RO.PeliEventit onTurnChanged;
        public RO.PeliEventit onPhaseChanged;
        public RO.StringVariable turnText;

        List<KorttiInstanssi> haudatutKortit = new List<KorttiInstanssi>();
        public RO.TransformiVariable hautuumaaVariable;

        public static PeliSäätäjä singleton;

        public GameObject MainCamera;
        public GameObject BattleCamera;
        public GameObject MainCanvas;
        public GameObject BattleCanvas;

        public GameObject EndTurnButton;

        public GameObject YourTurnText;
        public GameObject fadetoBlack;
        public GameObject VictoryText;
        public GameObject DefeatText;

        public AttackButtons attackButtons;

        public int AmountCardsLeft = 120;
        public int RoundNumber;

        //ForBot
        public KorttiTyyppi stattiTyyppi;
        public KorttiTyyppi minioniTyyppi;

        private void Awake()
        {
            MainCamera = GameObject.FindWithTag("MainCamera");
            BattleCamera = GameObject.FindWithTag("BattleCamera");
            MainCanvas = GameObject.FindWithTag("CardCanvas");
            BattleCanvas = GameObject.FindWithTag("BattleCanvas");

            attackButtons = GameObject.FindGameObjectWithTag("AttackButtons").GetComponent<AttackButtons>();

            singleton = this;

            RoundNumber = 1;

            if (botGame)
            {
                all_players = new PlayerHolder[2];
                for (int i = 0; i < 2; i++)
                {
                    all_players[i] = vuorot[i].player;
                }

                currentPlayer = vuorot[0].player;
            }
        }

        public void InitGame(int startingPlayer)
        {
            all_players = new PlayerHolder[2];
            //Vuoro[] _turns = new Vuoro[10];

            for (int i = 0; i < 2; i++)
            {
                all_players[i] = vuorot[i].player;

                if (all_players[1].photonId == startingPlayer)
                {
                    vuorot = vuorotNormaali;
                }
                else
                {
                    vuorot = vuorotReverse;
                }
            }

            //vuorot = _turns;

            SetupPlayers();

            turnText.value = vuorot[vuoroIndex].player.username;
            onTurnChanged.Raise();
            vuorot[0].OnTurnStart();
            isInit = true;
        }

        private void Start()
        {
            MainCamera = GameObject.FindWithTag("MainCamera");
            BattleCamera = GameObject.FindWithTag("BattleCamera");
            MainCanvas = GameObject.FindWithTag("CardCanvas");
            BattleCanvas = GameObject.FindWithTag("BattleCanvas");

            Settings.peliSäätäjä = this;

            if (botGame)
            {
                isInit = true;
                SetupPlayers();

                foreach (PlayerHolder p in all_players)
                {
                    p.Kulta = 10;
                    p.AmountCardsLeft = 60;
                    LuoAlotusKortit(p);
                    LuoAlotusKortit(p);
                    LuoAlotusKortit(p);
                    LuoAlotusKortit(p);
                }
                all_players[1].hasActiveMinions = false;
                vuorot[0].OnTurnStart();
                turnText.value = vuorot[vuoroIndex].player.username;
                onTurnChanged.Raise();
                
            }
        }

        void LuoAlotusKortit(PlayerHolder p)
        {
            ResurssiSäätäjä rs = Settings.GetResurssiSäätäjä();
            int Id = Random.Range(0, p.AmountCardsLeft);
            string cardId = p.all_cards[Id];
            p.all_cards.RemoveAt(Id);
            GameObject go = Instantiate(korttiPrefab) as GameObject;
            KortinAsentaja a = go.GetComponent<KortinAsentaja>();
            a.LataaKortti(rs.HaeKorttiInstanssi(cardId));
            KorttiInstanssi inst = go.GetComponent<KorttiInstanssi>();
            inst.currentLogic = p.käsilogiikka;
            Settings.SetParentForCard(go.transform, p.currentHolder.käsiGridi.value);
            p.AmountCardsLeft -= 1;
            p.kortitKädes.Add(inst);
        }

        public void PickNewCardFromDeck(PlayerHolder p)
        {
            if (p.all_cards.Count == 0)
            {
                Settings.RegisterEvent("You have run out of new cards! " + p.username, p.playerColor);
            }
            if (p.kortitKädes.Count > 9)
            {
                Settings.RegisterEvent("Your hand is full!", p.playerColor);
            }
            else
            {
                ResurssiSäätäjä rs = Settings.GetResurssiSäätäjä();
                int Id = Random.Range(0, p.AmountCardsLeft);
                string cardId = p.all_cards[Id];
                p.all_cards.RemoveAt(Id);
                GameObject go = Instantiate(korttiPrefab) as GameObject;
                KortinAsentaja a = go.GetComponent<KortinAsentaja>();
                a.LataaKortti(rs.HaeKorttiInstanssi(cardId));
                KorttiInstanssi inst = go.GetComponent<KorttiInstanssi>();
                inst.currentLogic = p.käsilogiikka;
                Settings.SetParentForCard(go.transform, p.currentHolder.käsiGridi.value);
                p.AmountCardsLeft -= 1;
                p.kortitKädes.Add(inst);
            }
        }

        public void UsedCardsInGraveyard(PlayerHolder p)
        {
            foreach (KorttiInstanssi k in p.kortitPöydällä.ToArray())
            {
                PutCardToGraveyard(k);
                //p.kortitPöydällä.Remove(k);
            }
            foreach (KorttiInstanssi k in p.kortitPöydällä.ToArray())
            {
                p.kortitPöydällä.Remove(k);
                p.CardToGraveyard(k);
            }
            p.ResetCardTurn = true;
        }

        public void BotPlayEveryCard(PlayerHolder p)
        {
            StartCoroutine(BotCardTurn(p));
        }

        public void BotChoocesAttack(PlayerHolder p)
        {
            for (int i = 0; i < attackButtons.Buttons.Length; i++)
            {
                attackButtons.Buttons[i].interactable = false;
            }

            StartCoroutine(BotBattleTurn(p));
        }

        public void BotAttacks(PlayerHolder p, int number)
        {
            if (number == 1)
                attackButtons.BotAttack1();

            if (number == 2)
                attackButtons.BotAttack2();

            if (number == 3)
                attackButtons.BotAttack3();

            if (number == 4)
                attackButtons.BotAttack4();
        }

        void BotPlaysCards(PlayerHolder p)
        {
            List<KorttiInstanssi> playableCards = new List<KorttiInstanssi>();

            playableCards.Clear();


            foreach (KorttiInstanssi k in p.kortitKädes.ToArray())
            {
                if (p.CanUseCard(k.asentaja.kortti))
                {
                    playableCards.Add(k);
                }
            }

            foreach (KorttiInstanssi k in playableCards)
            {
                p.DropCard(k);
                p.kortitKädes.Remove(k);

                if (k.asentaja.kortti.korttiTyyppi == stattiTyyppi)
                {
                    p.kortitPöydällä.Add(k);
                    BotStatCardsWork(k);
                    k.transform.SetParent(GameObject.FindWithTag("EnemyTable").transform);
                    k.transform.localPosition = Vector3.zero;
                    k.transform.localEulerAngles = Vector3.zero;
                    k.transform.localScale = new Vector3(0.7F, 0.7F, 0.7F);
                }
                if (k.asentaja.kortti.korttiTyyppi == minioniTyyppi)
                {
                    p.minionikortitPöydällä.Add(k);
                    BotMinionCardsWork(k);
                    k.transform.SetParent(GameObject.FindWithTag("EnemyMinionStack").transform);
                    k.transform.localPosition = Vector3.zero;
                    k.transform.localEulerAngles = Vector3.zero;
                    k.transform.localScale = new Vector3(0.7F, 0.7F, 0.7F);
                }
            }
        }

        void BotStatCardsWork(KorttiInstanssi k)
        {
            all_players[1].MonsterHealth += k.asentaja.kortti.AddHealth;
            all_players[1].MonsterAttack += k.asentaja.kortti.AddAttack;
            all_players[1].MonsterDefence += k.asentaja.kortti.AddDefence;
            all_players[1].MonsterArmor += k.asentaja.kortti.AddArmor;
            all_players[1].MonsterImpact += k.asentaja.kortti.AddImpact;
            all_players[1].MonsterPierce += k.asentaja.kortti.AddPierce;
            all_players[1].MonsterHealth -= k.asentaja.kortti.TakeHealth;
            all_players[1].MonsterDefence -= k.asentaja.kortti.TakeDefence;
            all_players[1].MonsterAttack -= k.asentaja.kortti.TakeAttack;

            if (k.asentaja.kortti.Death == true)
            {
                all_players[1].Minion1Health = k.asentaja.kortti.AddMinionHealth;
                all_players[1].Minion2Health = k.asentaja.kortti.AddMinionHealth;
                all_players[1].Minion3Health = k.asentaja.kortti.AddMinionHealth;
                all_players[1].Minion4Health = k.asentaja.kortti.AddMinionHealth;
            }
        }

        void BotMinionCardsWork(KorttiInstanssi k)
        {
            all_players[1].hasActiveMinions = true;
            all_players[1].PhasAmount = k.asentaja.kortti.AddPhas;
            all_players[1].AbasAmount = k.asentaja.kortti.AddAbas;
            all_players[1].TygoAmount = k.asentaja.kortti.AddTygo;
            all_players[1].Minion1Health = k.asentaja.kortti.AddMinionHealth;
            all_players[1].Minion2Health = k.asentaja.kortti.AddMinionHealth;
            all_players[1].Minion3Health = k.asentaja.kortti.AddMinionHealth;
            all_players[1].Minion4Health = k.asentaja.kortti.AddMinionHealth;
        }

        public void ActivateYourTurnText()
        {
            YourTurnText.SetActive(true);
        }

        public void ResetCoins(PlayerHolder p)
        {
            p.Kulta = 10;
        }

        public void GivePlayerCoincard(PlayerHolder p)
        {
            if (p.kortitKädes.Count > 9)
            {
                Settings.RegisterEvent("Your hand is full!", p.playerColor);
            }
            else
            {
                ResurssiSäätäjä rs = Settings.GetResurssiSäätäjä();
                string cardId = "Coin";
                GameObject go = Instantiate(korttiPrefab) as GameObject;
                KortinAsentaja a = go.GetComponent<KortinAsentaja>();
                a.LataaKortti(rs.HaeKorttiInstanssi(cardId));
                KorttiInstanssi inst = go.GetComponent<KorttiInstanssi>();
                inst.currentLogic = p.käsilogiikka;
                Settings.SetParentForCard(go.transform, p.currentHolder.käsiGridi.value);
                p.kortitKädes.Add(inst);
                p.MakeAllCoinCardsUsable();
            }
        }

        void AnnaKortti()
        {
            //ResurssiSäätäjä rs = Settings.GetResurssiSäätäjä();

            //for (int p = 0; p < all_players.Length; p++)
            //{
            //    for (int i = 0; i < all_players[p].alotusKortit.Length; i++)
            //    {
            //        GameObject go = Instantiate(korttiPrefab) as GameObject;
            //        KortinAsentaja a = go.GetComponent<KortinAsentaja>();
            //        a.LataaKortti(rs.HaeKorttiInstanssi(all_players[p].alotusKortit[i]));
            //        KorttiInstanssi inst = go.GetComponent<KorttiInstanssi>();
            //        inst.currentLogic = all_players[p].käsilogiikka;
            //        Settings.SetParentForCard(go.transform, all_players[p].currentHolder.käsiGridi.value);
            //        all_players[p].kortitKädes.Add(inst);
            //    }

            //    Settings.RegisterEvent("New cards have been drawn for " + all_players[p].username, all_players[p].playerColor);
            //}
        }

        void SetupPlayers()
        {
            for (int i = 0; i < all_players.Length; i++)
            {
                all_players[i].Init();

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

                all_players[1].startingDeck = all_players[0].startingDeck;
            }
        }

        private void Update()
        {
            if (Mestari == null)
                Mestari = GameObject.FindWithTag("Mestari").GetComponent<Mestarisäätäjä>();

            if (botGame == true)
                all_players[0].username = Mestari.Playername;

            if (!isInit)
                return;

            if (attackButtons == null)
                attackButtons = GameObject.FindGameObjectWithTag("AttackButtons").GetComponent<AttackButtons>();

            bool isComplete = vuorot[vuoroIndex].Execute();

            if (isComplete)
            {

                vuoroIndex++;
                if(vuoroIndex > vuorot.Length - 1)
                {
                    vuoroIndex = 0;
                }
                //The current player has changed here
                currentPlayer = vuorot[vuoroIndex].player;
                vuorot[vuoroIndex].OnTurnStart();
                turnText.value = vuorot[vuoroIndex].player.username;
                currentPlayer.coinsDroppedThisTurn = 0;
                onTurnChanged.Raise();
            }

            if(currentState != null)
            currentState.Tick(Time.deltaTime);        
            
            if (all_players[0].MonsterHealth > all_players[0].MonsterMaxHealth)
            {
                all_players[0].MonsterHealth = all_players[0].MonsterMaxHealth;
            }

            if (all_players[1].MonsterHealth > all_players[1].MonsterMaxHealth)
            {
                all_players[1].MonsterHealth = all_players[1].MonsterMaxHealth;
            }

            if (all_players[0].MonsterHealth < 0)
            {
                all_players[0].MonsterHealth = 0;
                Defeat();
            }

            if (all_players[1].MonsterHealth < 0)
            {
                all_players[1].MonsterHealth = 0;
                Victory();
            }

            if (all_players[0].PhasAmount == 0 && all_players[0].AbasAmount == 0 && all_players[0].TygoAmount == 0)
            {
                all_players[0].hasActiveMinions = false;
            }

            if (all_players[1].PhasAmount == 0 && all_players[1].AbasAmount == 0 && all_players[1].TygoAmount == 0)
            {
                all_players[1].hasActiveMinions = false;
            }
            if (all_players[0].Minion1Health < 0)
                all_players[0].Minion1Health = 0;
            if (all_players[0].Minion2Health < 0)
                all_players[0].Minion2Health = 0;
            if (all_players[0].Minion3Health < 0)
                all_players[0].Minion3Health = 0;
            if (all_players[0].Minion4Health < 0)
                all_players[0].Minion4Health = 0;
            if (all_players[1].Minion1Health < 0)
                all_players[1].Minion1Health = 0;
            if (all_players[1].Minion2Health < 0)
                all_players[1].Minion2Health = 0;
            if (all_players[1].Minion3Health < 0)
                all_players[1].Minion3Health = 0;
            if (all_players[1].Minion4Health < 0)
                all_players[1].Minion4Health = 0;

            if (all_players[0].Move1CD < 0)
                all_players[0].Move1CD = 0;
            if (all_players[0].Move2CD < 0)
                all_players[0].Move2CD = 0;
            if (all_players[0].Move3CD < 0)
                all_players[0].Move3CD = 0;
            if (all_players[0].Move4CD < 0)
                all_players[0].Move4CD = 0;
        }

        public void SetState(State state)
        {
            currentState = state;
        }

        public void EndCurrentPhase()
        {
            vuorot[vuoroIndex].EndCurrentPhase();

            Settings.RegisterEvent(vuorot[vuoroIndex].name + " finished", currentPlayer.playerColor);
        }

        public void CheckIfChangedPhase()
        {
            if (currentPlayer == all_players[1])
            {
                EndCurrentPhase();
            }
        }

        public void PutCardToGraveyard(KorttiInstanssi k)
        {
            haudatutKortit.Add(k);
            k.transform.SetParent(hautuumaaVariable.value);
            Vector3 p = Vector3.zero;
            k.transform.localRotation = Quaternion.identity;
            k.transform.localScale = new Vector3(0.7F, 0.7F, 0.7F);
        }

        public void Victory()
        {
            fadetoBlack.SetActive(true);
            VictoryText.SetActive(true);
        }

        public void Defeat()
        {
            fadetoBlack.SetActive(true);
            DefeatText.SetActive(true);
        }

        IEnumerator BotCardTurn(PlayerHolder p)
        {
            EndTurnButton.SetActive(false);
            yield return new WaitForSeconds(2);
            BotPlaysCards(p);
            yield return new WaitForSeconds(3);
            EndTurnButton.SetActive(true);
            EndCurrentPhase();
            //yield return new WaitForSeconds(2);
            //CheckIfChangedPhase();
        }

        IEnumerator BotBattleTurn(PlayerHolder p)
        {
            int number = Random.Range(1, 5);
            yield return new WaitForSeconds(2);
            BotAttacks(p, number);
        }
    }
}
