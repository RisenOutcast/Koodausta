using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RO.GameElements;

namespace RO
{
    [CreateAssetMenu(menuName = "Holders/Player Holder")]
    public class PlayerHolder : ScriptableObject
    {
        public string username;
        public Color playerColor;

        [System.NonSerialized]
        public int photonId = -1;


        public bool Grontto;
        public bool Angira;

        //public string[] alotusKortit;
        public List<string> startingDeck = new List<string>();
        [System.NonSerialized]
        public List<string> all_cards = new List<string>();

        public int coinsPerTurn = 10;
        [System.NonSerialized]
        public int coinsDroppedThisTurn;
        public int goldDroppedThisTurn;

        public int Kulta;

        public bool isHumanPlayer;

        public int AmountCardsLeft = 60;

        public GameElementLogic käsilogiikka;
        public GameElementLogic pöytälogiikka;

        public bool hasActiveMinions = false;

        public int PhasAmount = 0;
        public int AbasAmount = 0;
        public int TygoAmount = 0;

        int AllAmount;

        public int Minion1Health;
        public int Minion2Health;
        public int Minion3Health;
        public int Minion4Health;

        public int Move1CD = 0;
        public int Move2CD = 0;
        public int Move3CD = 0;
        public int Move4CD = 0;

        [System.NonSerialized]
        public CardHolders currentHolder;

        [System.NonSerialized]
        public List<KorttiInstanssi> kortitKädes = new List<KorttiInstanssi>();
        [System.NonSerialized]
        public List<KorttiInstanssi> kortitPöydällä = new List<KorttiInstanssi>();
        [System.NonSerialized]
        public List<KorttiInstanssi> minionikortitPöydällä = new List<KorttiInstanssi>();
        [System.NonSerialized]
        public List<CoinHolder> coinlist = new List<CoinHolder>();

        public bool ResetCardTurn;

        public bool TakingDamage;

        #region //MonsterAttributes
        public string MonsterName;
        public int MonsterHealth;
        public int MonsterAttack;
        public int MonsterDefence;
        public int MonsterArmor;
        public int MonsterImpact;
        public int MonsterPierce;

        public bool MonsterBleed;

        public int MonsterMaxHealth;

        #endregion

        public void Init()
        {
            all_cards.AddRange(startingDeck);
            hasActiveMinions = false;
    }

        public int KolikkoCount
        {
            get { return currentHolder.rahaGridi.value.GetComponentsInChildren<KortinAsentaja>().Length; }
        }

        public void CardToGraveyard(KorttiInstanssi k)
        {
            if (kortitKädes.Contains(k))
                kortitKädes.Remove(k);
            if (kortitPöydällä.Contains(k))
                kortitPöydällä.Remove(k);
            ResetCardTurn = true;
        }

        public void AddCoinCard(GameObject cardObject)
        {
            CoinHolder coinHolder = new CoinHolder
            {
                cardObject = cardObject
            };

            coinlist.Add(coinHolder);
            coinsDroppedThisTurn++;

            Settings.RegisterEvent(username + " Played Coin", Color.white);
        }

        public int NonUsedCards()
        {
            int result = 0;

            for (int i = 0; i < coinlist.Count; i++)
            {
                if (!coinlist[i].isUsed)
                {
                    result++;
                }
            }

            return result;
        }

        public bool CanUseCard(Kortti k)
        {
            bool result = false;

            if (k.korttiTyyppi is MinioniKorttityyppi)
            {
                if (hasActiveMinions == true)
                {
                    result = false;
                    if (!Settings.peliSäätäjä.botGame || Settings.peliSäätäjä.currentPlayer.isHumanPlayer)
                        Settings.RegisterEvent("You have active minions!", Color.red);
                    Debug.Log("You have active minions!");
                }
                else
                {
                    if (k.Hinta <= Kulta)
                    {
                        Kulta -= k.Hinta;
                        result = true;
                        hasActiveMinions = true;
                    }
                    else
                    {
                        result = false;
                        if (!Settings.peliSäätäjä.botGame || Settings.peliSäätäjä.currentPlayer.isHumanPlayer)
                            Settings.RegisterEvent("Not enough gold to use card", Color.red);
                        Debug.Log("Not enough gold to use card");
                    }
                }
            }

            if (k.korttiTyyppi is SpelliKorttityyppi || k.korttiTyyppi is CatalystKorttityyppi || k.korttiTyyppi is StattiKorttityyppi)
            {

                if (k.Death == true)
                {
                    AllAmount = PhasAmount + AbasAmount + TygoAmount;
                    if (AllAmount < 4)
                    {
                        result = false;
                        if (!Settings.peliSäätäjä.botGame || Settings.peliSäätäjä.currentPlayer.isHumanPlayer)
                            Settings.RegisterEvent("You must have 4 active minions!", Color.red);
                        Debug.Log("You must have 4 active minions!");
                    }
                    else
                    {
                        if (k.Hinta <= Kulta)
                        {
                            Kulta -= k.Hinta;
                            result = true;
                        }
                        else
                        {
                            result = false;
                            if (!Settings.peliSäätäjä.botGame || Settings.peliSäätäjä.currentPlayer.isHumanPlayer)
                                Settings.RegisterEvent("Not enough gold to use card", Color.red);
                            Debug.Log("Not enough gold to use card");
                        }

                    }
                }
                if (k.Shaman == true)
                {
                    if (k.Hinta <= Kulta)
                    {
                        Kulta -= k.Hinta;
                        result = true;
                        Settings.peliSäätäjä.PickNewCardFromDeck(this);
                        Settings.peliSäätäjä.PickNewCardFromDeck(this);
                    }
                    else
                    {
                        result = false;
                        if (!Settings.peliSäätäjä.botGame || Settings.peliSäätäjä.currentPlayer.isHumanPlayer)
                            Debug.Log("Not enough gold to use card");
                    }
                }
                if (k.Raven == true)
                {
                    AllAmount = Settings.peliSäätäjä.all_players[1].PhasAmount + Settings.peliSäätäjä.all_players[1].AbasAmount + Settings.peliSäätäjä.all_players[1].TygoAmount;
                    if (AllAmount < 4)
                    {
                        result = false;
                        if (!Settings.peliSäätäjä.botGame || Settings.peliSäätäjä.currentPlayer.isHumanPlayer)
                            Settings.RegisterEvent("Enemy must have 4 active minions!", Color.red);
                        Debug.Log("Enemy must have 4 active minions!");
                    }
                    else
                    {
                        if (k.Hinta <= Kulta)
                        {
                            Kulta -= k.Hinta;
                            result = true;
                            Settings.peliSäätäjä.all_players[1].Minion1Health = 0;
                            Settings.peliSäätäjä.all_players[1].Minion2Health = 0;
                            Settings.peliSäätäjä.all_players[1].Minion3Health = 0;
                            Settings.peliSäätäjä.all_players[1].Minion4Health = 0;
                        }
                        else
                        {
                            result = false;
                            if (!Settings.peliSäätäjä.botGame || Settings.peliSäätäjä.currentPlayer.isHumanPlayer)
                                Settings.RegisterEvent("Not enough gold to use card", Color.red);
                            Debug.Log("Not enough gold to use card");
                        }

                    }
                }
                if (k.Death == false && k.Shaman == false && k.Raven == false)
                {
                    if (k.Hinta <= Kulta)
                    {
                        Kulta -= k.Hinta;
                        result = true;
                    }
                    else
                    {
                        result = false;
                        if (!Settings.peliSäätäjä.botGame || Settings.peliSäätäjä.currentPlayer.isHumanPlayer)
                            Debug.Log("Not enough gold to use card");
                    }
                }
            }
            else
            {
                if (k.korttiTyyppi is KolikkoKorttityyppi)
                {
                    if (coinsPerTurn - coinsDroppedThisTurn > 0)
                    {
                            result = true;

                    }
                }
            }
            return result;
        }

        public void DropCard(KorttiInstanssi inst)
        {
            if (kortitKädes.Contains(inst))
                kortitKädes.Remove(inst);

            kortitPöydällä.Add(inst);

            Settings.RegisterEvent(username + " played " + inst.asentaja.kortti.name, Color.white);
        }

        public void DropMinionCard(KorttiInstanssi inst)
        {
            if (kortitKädes.Contains(inst))
                kortitKädes.Remove(inst);

            minionikortitPöydällä.Add(inst);

            Settings.RegisterEvent(username + " played " + inst.asentaja.kortti.name, Color.white);
        }

        public List<CoinHolder> GetUnusedCoins()
        {
            List<CoinHolder> result = new List<CoinHolder>();

            for (int i = 0; i < coinlist.Count; i++)
            {
                if (!coinlist[i].isUsed)
                {
                    result.Add(coinlist[i]);
                }
            }

            return result;
        }

        public void MakeAllCoinCardsUsable()
        {
            for (int i = 0; i < coinlist.Count; i++)
            {
                coinlist[i].isUsed = false;
                coinlist[i].cardObject.transform.localEulerAngles = Vector3.zero;
            }
        }

        public void UseCoinCards(int amount)
        {
            Vector3 euler = new Vector3(0, 0, 90);

            List<CoinHolder> l = GetUnusedCoins();

            for (int i = 0; i < amount; i++)
            {
                l[i].isUsed = true;
                l[i].cardObject.transform.localEulerAngles = euler;
            }

            coinsDroppedThisTurn++;
        }
    }
}