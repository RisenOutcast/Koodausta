using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RO
{
    public class UpdateHealthbars : MonoBehaviour
    {
        public TMP_Text User1Name;
        public TMP_Text User2Name;

        public TMP_Text User1Name2;
        public TMP_Text User2Name2;

        public Slider User1Healthbar;
        public TMP_Text User1HealthText;

        public Slider User2Healthbar;
        public TMP_Text User2HealthText;

        // Use this for initialization
        void Start()
        {
            Settings.peliSäätäjä.all_players[0].Grontto = true;

            Settings.peliSäätäjä.all_players[0].MonsterName = "Grontto";
            Settings.peliSäätäjä.all_players[0].MonsterHealth = 4600;
            Settings.peliSäätäjä.all_players[0].MonsterMaxHealth = 4600;
            Settings.peliSäätäjä.all_players[0].MonsterAttack = 745;
            Settings.peliSäätäjä.all_players[0].MonsterDefence = 950;
            Settings.peliSäätäjä.all_players[0].MonsterArmor = 320;
            Settings.peliSäätäjä.all_players[0].MonsterImpact = 250;
            Settings.peliSäätäjä.all_players[0].MonsterPierce = 150;

            Settings.peliSäätäjä.all_players[0].PhasAmount = 0;
            Settings.peliSäätäjä.all_players[0].AbasAmount = 0;
            Settings.peliSäätäjä.all_players[0].TygoAmount = 0;
            Settings.peliSäätäjä.all_players[0].Minion1Health = 0;
            Settings.peliSäätäjä.all_players[0].Minion2Health = 0;
            Settings.peliSäätäjä.all_players[0].Minion3Health = 0;
            Settings.peliSäätäjä.all_players[0].Minion4Health = 0;
            Settings.peliSäätäjä.all_players[0].hasActiveMinions = false;

            Settings.peliSäätäjä.all_players[0].Move1CD = 0;
            Settings.peliSäätäjä.all_players[0].Move2CD = 0;
            Settings.peliSäätäjä.all_players[0].Move3CD = 0;
            Settings.peliSäätäjä.all_players[0].Move4CD = 0;

            Settings.peliSäätäjä.all_players[1].Grontto = true;

            Settings.peliSäätäjä.all_players[1].MonsterName = "Grontto";
            Settings.peliSäätäjä.all_players[1].MonsterHealth = 4600;
            Settings.peliSäätäjä.all_players[1].MonsterMaxHealth = 4600;
            Settings.peliSäätäjä.all_players[1].MonsterAttack = 745;
            Settings.peliSäätäjä.all_players[1].MonsterDefence = 950;
            Settings.peliSäätäjä.all_players[1].MonsterArmor = 320;
            Settings.peliSäätäjä.all_players[1].MonsterImpact = 250;
            Settings.peliSäätäjä.all_players[1].MonsterPierce = 150;

            Settings.peliSäätäjä.all_players[1].PhasAmount = 0;
            Settings.peliSäätäjä.all_players[1].AbasAmount = 0;
            Settings.peliSäätäjä.all_players[1].TygoAmount = 0;
            Settings.peliSäätäjä.all_players[1].Minion1Health = 0;
            Settings.peliSäätäjä.all_players[1].Minion2Health = 0;
            Settings.peliSäätäjä.all_players[1].Minion3Health = 0;
            Settings.peliSäätäjä.all_players[1].Minion4Health = 0;
            Settings.peliSäätäjä.all_players[1].hasActiveMinions = false;

            Settings.peliSäätäjä.all_players[1].Move1CD = 0;
            Settings.peliSäätäjä.all_players[1].Move2CD = 0;
            Settings.peliSäätäjä.all_players[1].Move3CD = 0;
            Settings.peliSäätäjä.all_players[1].Move4CD = 0;

            if (Settings.peliSäätäjä.botGame)
            {
                Settings.peliSäätäjä.all_players[1].username = "Ancient Bot";
                Settings.peliSäätäjä.all_players[1].startingDeck = Settings.peliSäätäjä.all_players[0].startingDeck;
            }
        }

        // Update is called once per frame
        void Update()
        {
            User1Name.text = Settings.peliSäätäjä.all_players[0].username;
            User2Name.text = Settings.peliSäätäjä.all_players[1].username;

            User1Name2.text = Settings.peliSäätäjä.all_players[0].username;
            User2Name2.text = Settings.peliSäätäjä.all_players[1].username;


            User1Healthbar.value = Settings.peliSäätäjä.all_players[0].MonsterHealth;
            User1Healthbar.maxValue = Settings.peliSäätäjä.all_players[0].MonsterMaxHealth;
            User1HealthText.text = (Settings.peliSäätäjä.all_players[0].MonsterHealth + "/" + Settings.peliSäätäjä.all_players[0].MonsterMaxHealth).ToString();

            User2Healthbar.value = Settings.peliSäätäjä.all_players[1].MonsterHealth;
            User2Healthbar.maxValue = Settings.peliSäätäjä.all_players[1].MonsterMaxHealth;
            User2HealthText.text = (Settings.peliSäätäjä.all_players[1].MonsterHealth + "/" + Settings.peliSäätäjä.all_players[0].MonsterMaxHealth).ToString();
        }
    }
}