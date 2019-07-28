using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RO {
    public class ShowMonsterDetails : MonoBehaviour {

        public string MonsterName;
        public int MonsterHealth;
        public int MonsterMaxHealth;
        public int MonsterAttack;
        public int MonsterDefence;
        public int MonsterArmor;
        public int MonsterImpact;
        public int MonsterPierce;

        public TMP_Text Name;
        public TMP_Text Health;
        public TMP_Text Attack;
        public TMP_Text Defence;
        public TMP_Text Armor;
        public TMP_Text Impact;
        public TMP_Text Pierce;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

            MonsterName = Settings.peliSäätäjä.all_players[0].MonsterName;
            MonsterHealth = Settings.peliSäätäjä.all_players[0].MonsterHealth;
            MonsterMaxHealth = Settings.peliSäätäjä.all_players[0].MonsterMaxHealth;
            MonsterAttack = Settings.peliSäätäjä.all_players[0].MonsterAttack;
            MonsterDefence = Settings.peliSäätäjä.all_players[0].MonsterDefence;
            MonsterArmor = Settings.peliSäätäjä.all_players[0].MonsterArmor;
            MonsterImpact = Settings.peliSäätäjä.all_players[0].MonsterImpact;
            MonsterPierce = Settings.peliSäätäjä.all_players[0].MonsterPierce;

            Name.text = MonsterName;
            Health.text = "Health: " + MonsterHealth.ToString() + "/" + MonsterMaxHealth.ToString();
            Attack.text = "Attack: " + MonsterAttack.ToString();
            Defence.text = "Defence: " + MonsterDefence.ToString();
            Armor.text = "Armor: " + MonsterArmor.ToString();
            Impact.text = "Impact: " + MonsterImpact.ToString();
            Pierce.text = "Pierce: " + MonsterPierce.ToString();

        }
    }
}