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
        public string[] alotusKortit;

        public int coinsPerTurn = 1;
        [System.NonSerialized]
        public int coinsDroppedThisTurn;

        public bool isHumanPlayer;

        public GameElementLogic käsilogiikka;
        public GameElementLogic pöytälogiikka;

        [System.NonSerialized]
        public CardHolders currentHolder;

        [System.NonSerialized]
        public List<KorttiInstanssi> kortitKädes = new List<KorttiInstanssi>();
        [System.NonSerialized]
        public List<KorttiInstanssi> kortitPöydällä = new List<KorttiInstanssi>();
        [System.NonSerialized]
        public List<CoinHolder> coinlist = new List<CoinHolder>();

        public int KolikkoCount
        {
            get { return currentHolder.rahaGridi.value.GetComponentsInChildren<KortinAsentaja>().Length; }
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

            if(k.korttiTyyppi is MinioniKorttityyppi || k.korttiTyyppi is SpelliKorttityyppi || k.korttiTyyppi is CatalystKorttityyppi || k.korttiTyyppi is StattiKorttityyppi)
            {
                int currentCoins = NonUsedCards();
                if (k.Hinta <= currentCoins)
                    result = true;
            }
            else
            {
                if (k.korttiTyyppi is KolikkoKorttityyppi)
                {
                    result = true;
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
        }
    }
}