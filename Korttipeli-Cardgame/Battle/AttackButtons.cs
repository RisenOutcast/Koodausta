using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RO
{
    public class AttackButtons : MonoBehaviour
    {

        public TMP_Text MoveText;

        public TMP_Text Move1Name;
        public TMP_Text Move2Name;
        public TMP_Text Move3Name;
        public TMP_Text Move4Name;

        public float P1Damage;
        public int ArmorPierced;
        public int DefencePierced;

        public int PhasDMG = 20;
        public int TygoDMG = 25;
        public int AbasDMG = 15;

        public float  P1CleanDamage;

        public float BotCleanDamage;
        public float BotDamage;

        public int TestDMGImpact;
        public int TestDMGAttack;
        public int TestDMG;

        public GameObject[] Minions;
        public GameObject[] Monsters;

        public GameObject[] BotMonsters;
        public GameObject[] BotMinions;

        public Button[] Buttons;



        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            P1CleanDamage = Settings.peliSäätäjä.all_players[0].MonsterImpact * Settings.peliSäätäjä.all_players[0].MonsterAttack / (Settings.peliSäätäjä.all_players[0].MonsterAttack + Settings.peliSäätäjä.all_players[1].MonsterDefence + (Settings.peliSäätäjä.all_players[1].MonsterArmor - Settings.peliSäätäjä.all_players[0].MonsterPierce));

            if (Settings.peliSäätäjä.botGame)
                BotCleanDamage = Settings.peliSäätäjä.all_players[1].MonsterImpact * Settings.peliSäätäjä.all_players[1].MonsterAttack / (Settings.peliSäätäjä.all_players[1].MonsterAttack + Settings.peliSäätäjä.all_players[0].MonsterDefence + (Settings.peliSäätäjä.all_players[0].MonsterArmor - Settings.peliSäätäjä.all_players[1].MonsterPierce));

            //ArmorPierced = Settings.peliSäätäjä.all_players[1].MonsterArmor - Settings.peliSäätäjä.all_players[0].MonsterPierce;
            //DefencePierced = Settings.peliSäätäjä.all_players[1].MonsterDefence - Settings.peliSäätäjä.all_players[0].MonsterPierce;
            //P1CleanDamage = (Settings.peliSäätäjä.all_players[0].MonsterImpact / DefencePierced) * (Settings.peliSäätäjä.all_players[0].MonsterAttack / ArmorPierced);
            //TestDMGImpact = Settings.peliSäätäjä.all_players[0].MonsterImpact / ArmorPierced;
            //TestDMGAttack = Settings.peliSäätäjä.all_players[0].MonsterAttack * 2 / DefencePierced;
            //TestDMG = 45 * TestDMGImpact * TestDMGAttack;

            #region Minion lisäys
            if (Settings.peliSäätäjä.all_players[0].hasActiveMinions == false)
            {
                P1Damage = P1CleanDamage;
            }

            if(Settings.peliSäätäjä.all_players[0].hasActiveMinions == true && Settings.peliSäätäjä.all_players[0].PhasAmount > 0)
            {
                P1Damage = P1CleanDamage + (PhasDMG * Settings.peliSäätäjä.all_players[0].PhasAmount);
            }

            if (Settings.peliSäätäjä.all_players[0].hasActiveMinions == true && Settings.peliSäätäjä.all_players[0].TygoAmount > 0)
            {
                P1Damage = P1CleanDamage + (TygoDMG * Settings.peliSäätäjä.all_players[0].TygoAmount);
            }

            if (Settings.peliSäätäjä.all_players[0].hasActiveMinions == true && Settings.peliSäätäjä.all_players[0].AbasAmount > 0)
            {
                P1Damage = P1CleanDamage + (AbasDMG * Settings.peliSäätäjä.all_players[0].AbasAmount);
            }

            #endregion

            #region BotMinion lisäys
            if (Settings.peliSäätäjä.botGame)
            {
                if (Settings.peliSäätäjä.all_players[1].hasActiveMinions == false)
                {
                    BotDamage = BotCleanDamage;
                }

                if (Settings.peliSäätäjä.all_players[1].hasActiveMinions == true && Settings.peliSäätäjä.all_players[1].PhasAmount > 0)
                {
                    BotDamage = BotCleanDamage + (PhasDMG * Settings.peliSäätäjä.all_players[1].PhasAmount);
                }

                if (Settings.peliSäätäjä.all_players[1].hasActiveMinions == true && Settings.peliSäätäjä.all_players[1].TygoAmount > 0)
                {
                    BotDamage = BotCleanDamage + (TygoDMG * Settings.peliSäätäjä.all_players[1].TygoAmount);
                }

                if (Settings.peliSäätäjä.all_players[1].hasActiveMinions == true && Settings.peliSäätäjä.all_players[1].AbasAmount > 0)
                {
                    BotDamage = BotCleanDamage + (AbasDMG * Settings.peliSäätäjä.all_players[1].AbasAmount);
                }
            }
            #endregion

            if (RO.Settings.peliSäätäjä.all_players[0].Angira == true)
            {
                Move1Name.text = "AngiraMove1";
                Move2Name.text = "AngiraMove2";
                Move3Name.text = "AngiraMove3";
                Move4Name.text = "AngiraMove4";
            }

            if (RO.Settings.peliSäätäjä.all_players[0].Grontto == true)
            {
                Move1Name.text = "Crunch";
                Move2Name.text = "Stomp";
                Move3Name.text = "Flamethrower";
                Move4Name.text = "Slap";
            }
        }

        #region Attacks

        public void Attack1()
        {
            int number = Random.Range(1, 1);
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].interactable = false;
            }

            MoveText.text = "Grontto used Crunch!";
            //AnimaatioStart
            foreach (GameObject mon in Monsters)
            {
                Animator anim = mon.GetComponent<Animator>();
                if (mon.activeSelf)
                {
                    anim.SetBool("Attack1", true);
                }
            }
            if (Settings.peliSäätäjä.all_players[0].hasActiveMinions == true)
            {
                foreach (GameObject min in Minions)
                {
                    if (min.activeSelf)
                        min.GetComponent<Animator>().SetBool("Attack", true);
                }
            }
            //DamageDealt
            if (RO.Settings.peliSäätäjä.all_players[0].Grontto == true)
            {
                Settings.peliSäätäjä.all_players[1].MonsterHealth -= Mathf.RoundToInt(1.2F * P1Damage);
                Settings.peliSäätäjä.all_players[0].MonsterHealth += Mathf.RoundToInt(0.03F * Settings.peliSäätäjä.all_players[1].MonsterHealth);

                if (Settings.peliSäätäjä.all_players[1].hasActiveMinions == true)
                {
                    //Deal damage to enemy minions.
                    Settings.peliSäätäjä.all_players[1].Minion1Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[1].Minion2Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[1].Minion3Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[1].Minion4Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                }
            }
            //Enemy Hurt Animation start
            Settings.peliSäätäjä.all_players[1].TakingDamage = true;

            Settings.peliSäätäjä.all_players[0].Move1CD = 2;
            Settings.peliSäätäjä.all_players[0].Move2CD -= 1;
            Settings.peliSäätäjä.all_players[0].Move3CD -= 1;
            Settings.peliSäätäjä.all_players[0].Move4CD -= 1;
        }

        public void Attack2()
        {
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].interactable = false;
            }

            MoveText.text = "Grontto used Stomp!";
            //AnimaatioStart
            foreach (GameObject mon in Monsters)
            {
                Animator anim = mon.GetComponent<Animator>();
                if (mon.activeSelf)
                {
                    anim.SetBool("Attack2", true);
                }
            }
            if (Settings.peliSäätäjä.all_players[0].hasActiveMinions == true)
            {
                foreach (GameObject min in Minions)
                {
                    if (min.activeSelf)
                        min.GetComponent<Animator>().SetBool("Attack", true);
                }
            }
            //DamageDealt
            if (RO.Settings.peliSäätäjä.all_players[0].Grontto == true)
            {
                Settings.peliSäätäjä.all_players[1].MonsterHealth -= Mathf.RoundToInt(P1Damage);
                Settings.peliSäätäjä.all_players[1].MonsterArmor -= Mathf.RoundToInt(0.2F * P1Damage);

                if (Settings.peliSäätäjä.all_players[1].hasActiveMinions == true)
                {
                    //Deal damage to enemy minions.
                    Settings.peliSäätäjä.all_players[1].Minion1Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[1].Minion2Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[1].Minion3Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[1].Minion4Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                }
            }
            //Enemy Hurt Animation start
            Settings.peliSäätäjä.all_players[1].TakingDamage = true;

            Settings.peliSäätäjä.all_players[0].Move1CD -= 1;
            Settings.peliSäätäjä.all_players[0].Move2CD = 4;
            Settings.peliSäätäjä.all_players[0].Move3CD -= 1;
            Settings.peliSäätäjä.all_players[0].Move4CD -= 1;
        }

        public void Attack3()
        {
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].interactable = false;
            }

            MoveText.text = "Grontto used Flamethrower!";
            //AnimaatioStart
            foreach (GameObject mon in Monsters)
            {
                Animator anim = mon.GetComponent<Animator>();
                if (mon.activeSelf)
                {
                    anim.SetBool("Attack3", true);
                }
            }
            if (Settings.peliSäätäjä.all_players[0].hasActiveMinions == true)
            {
                foreach (GameObject min in Minions)
                {
                    if (min.activeSelf)
                        min.GetComponent<Animator>().SetBool("Attack", true);
                }
            }
            //DamageDealt
            if (RO.Settings.peliSäätäjä.all_players[0].Grontto == true)
            {
                Settings.peliSäätäjä.all_players[1].MonsterHealth -= Mathf.RoundToInt(P1Damage);

                if (Settings.peliSäätäjä.all_players[1].hasActiveMinions == true)
                {
                    //Deal damage to enemy minions.
                    Settings.peliSäätäjä.all_players[1].Minion1Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[1].Minion2Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[1].Minion3Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[1].Minion4Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                }
            }
            //Enemy Hurt Animation start
            Settings.peliSäätäjä.all_players[1].TakingDamage = true;

            Settings.peliSäätäjä.all_players[0].Move1CD -= 1;
            Settings.peliSäätäjä.all_players[0].Move2CD -= 1;
            Settings.peliSäätäjä.all_players[0].Move3CD = 6;
            Settings.peliSäätäjä.all_players[0].Move4CD -= 1;
        }

        public void Attack4()
        {
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].interactable = false;
            }

            MoveText.text = "Grontto used Slap!";
            //AnimaatioStart
            foreach (GameObject mon in Monsters)
            {
                Animator anim = mon.GetComponent<Animator>();
                if (mon.activeSelf)
                {
                    anim.SetBool("Attack4", true);
                }
            }
            if (Settings.peliSäätäjä.all_players[0].hasActiveMinions == true)
            {
                foreach (GameObject min in Minions)
                {
                    if (min.activeSelf)
                        min.GetComponent<Animator>().SetBool("Attack", true);
                }
            }
            //DamageDealt
            if (RO.Settings.peliSäätäjä.all_players[0].Grontto == true)
            {
                Settings.peliSäätäjä.all_players[1].MonsterHealth -= Mathf.RoundToInt(P1Damage);

                if (Settings.peliSäätäjä.all_players[1].hasActiveMinions == true)
                {
                    //Deal damage to enemy minions.
                    Settings.peliSäätäjä.all_players[1].Minion1Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[1].Minion2Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[1].Minion3Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[1].Minion4Health -= Mathf.RoundToInt(P1Damage / Random.Range(4, 7));
                }
            }
            //Enemy Hurt Animation start
            Settings.peliSäätäjä.all_players[1].TakingDamage = true;

            Settings.peliSäätäjä.all_players[0].Move1CD -= 1;
            Settings.peliSäätäjä.all_players[0].Move2CD -= 1;
            Settings.peliSäätäjä.all_players[0].Move3CD -= 1;
            Settings.peliSäätäjä.all_players[0].Move4CD = 0;
        }
        #endregion

        #region Bot Attacks
        public void BotAttack1()
        {
            int number = Random.Range(1, 1);

            MoveText.text = "Grontto used Crunch!";
            //AnimaatioStart
            foreach (GameObject mon in BotMonsters)
            {
                Animator anim = mon.GetComponent<Animator>();
                if (mon.activeSelf)
                {
                    anim.SetBool("Attack1", true);
                }
            }
            if (Settings.peliSäätäjä.all_players[1].hasActiveMinions == true)
            {
                foreach (GameObject min in BotMinions)
                {
                    if (min.activeSelf)
                        min.GetComponent<Animator>().SetBool("Attack", true);
                }
            }
            //DamageDealt
            if (RO.Settings.peliSäätäjä.all_players[1].Grontto == true)
            {
                Settings.peliSäätäjä.all_players[0].MonsterHealth -= Mathf.RoundToInt(1.2F * BotDamage);
                Settings.peliSäätäjä.all_players[1].MonsterHealth += Mathf.RoundToInt(0.03F * Settings.peliSäätäjä.all_players[0].MonsterHealth);

                if (Settings.peliSäätäjä.all_players[0].hasActiveMinions == true)
                {
                    //Deal damage to enemy minions.
                    Settings.peliSäätäjä.all_players[0].Minion1Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[0].Minion2Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[0].Minion3Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[0].Minion4Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                }
            }
            //Enemy Hurt Animation start
            Settings.peliSäätäjä.all_players[0].TakingDamage = true;

            Settings.peliSäätäjä.all_players[1].Move1CD = 2;
            Settings.peliSäätäjä.all_players[1].Move2CD -= 1;
            Settings.peliSäätäjä.all_players[1].Move3CD -= 1;
            Settings.peliSäätäjä.all_players[1].Move4CD -= 1;
        }

        public void BotAttack2()
        {

            MoveText.text = "Grontto used Stomp!";
            //AnimaatioStart
            foreach (GameObject mon in BotMonsters)
            {
                Animator anim = mon.GetComponent<Animator>();
                if (mon.activeSelf)
                {
                    anim.SetBool("Attack2", true);
                }
            }
            if (Settings.peliSäätäjä.all_players[1].hasActiveMinions == true)
            {
                foreach (GameObject min in BotMinions)
                {
                    if (min.activeSelf)
                        min.GetComponent<Animator>().SetBool("Attack", true);
                }
            }
            //DamageDealt
            if (RO.Settings.peliSäätäjä.all_players[1].Grontto == true)
            {
                Settings.peliSäätäjä.all_players[0].MonsterHealth -= Mathf.RoundToInt(BotDamage);
                Settings.peliSäätäjä.all_players[0].MonsterArmor -= Mathf.RoundToInt(0.2F * BotDamage);

                if (Settings.peliSäätäjä.all_players[0].hasActiveMinions == true)
                {
                    //Deal damage to enemy minions.
                    Settings.peliSäätäjä.all_players[0].Minion1Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[0].Minion2Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[0].Minion3Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[0].Minion4Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                }
            }
            //Enemy Hurt Animation start
            Settings.peliSäätäjä.all_players[0].TakingDamage = true;

            Settings.peliSäätäjä.all_players[1].Move1CD -= 1;
            Settings.peliSäätäjä.all_players[1].Move2CD = 4;
            Settings.peliSäätäjä.all_players[1].Move3CD -= 1;
            Settings.peliSäätäjä.all_players[1].Move4CD -= 1;
        }

        public void BotAttack3()
        {
            MoveText.text = "Grontto used Flamethrower!";
            //AnimaatioStart
            foreach (GameObject mon in BotMonsters)
            {
                Animator anim = mon.GetComponent<Animator>();
                if (mon.activeSelf)
                {
                    anim.SetBool("Attack3", true);
                }
            }
            if (Settings.peliSäätäjä.all_players[1].hasActiveMinions == true)
            {
                foreach (GameObject min in BotMinions)
                {
                    if (min.activeSelf)
                        min.GetComponent<Animator>().SetBool("Attack", true);
                }
            }
            //DamageDealt
            if (RO.Settings.peliSäätäjä.all_players[1].Grontto == true)
            {
                Settings.peliSäätäjä.all_players[0].MonsterHealth -= Mathf.RoundToInt(BotDamage);

                if (Settings.peliSäätäjä.all_players[0].hasActiveMinions == true)
                {
                    //Deal damage to enemy minions.
                    Settings.peliSäätäjä.all_players[0].Minion1Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[0].Minion2Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[0].Minion3Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[0].Minion4Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                }
            }
            //Enemy Hurt Animation start
            Settings.peliSäätäjä.all_players[0].TakingDamage = true;

            Settings.peliSäätäjä.all_players[1].Move1CD -= 1;
            Settings.peliSäätäjä.all_players[1].Move2CD -= 1;
            Settings.peliSäätäjä.all_players[1].Move3CD = 6;
            Settings.peliSäätäjä.all_players[1].Move4CD -= 1;
        }

        public void BotAttack4()
        {
            MoveText.text = "Grontto used Slap!";
            //AnimaatioStart
            foreach (GameObject mon in BotMonsters)
            {
                Animator anim = mon.GetComponent<Animator>();
                if (mon.activeSelf)
                {
                    anim.SetBool("Attack4", true);
                }
            }
            if (Settings.peliSäätäjä.all_players[1].hasActiveMinions == true)
            {
                foreach (GameObject min in BotMinions)
                {
                    if (min.activeSelf)
                        min.GetComponent<Animator>().SetBool("Attack", true);
                }
            }
            //DamageDealt
            if (RO.Settings.peliSäätäjä.all_players[1].Grontto == true)
            {
                Settings.peliSäätäjä.all_players[0].MonsterHealth -= Mathf.RoundToInt(BotDamage);

                if (Settings.peliSäätäjä.all_players[0].hasActiveMinions == true)
                {
                    //Deal damage to enemy minions.
                    Settings.peliSäätäjä.all_players[0].Minion1Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[0].Minion2Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[0].Minion3Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                    Settings.peliSäätäjä.all_players[0].Minion4Health -= Mathf.RoundToInt(BotDamage / Random.Range(4, 7));
                }
            }
            //Enemy Hurt Animation start
            Settings.peliSäätäjä.all_players[0].TakingDamage = true;

            Settings.peliSäätäjä.all_players[1].Move1CD -= 1;
            Settings.peliSäätäjä.all_players[1].Move2CD -= 1;
            Settings.peliSäätäjä.all_players[1].Move3CD -= 1;
            Settings.peliSäätäjä.all_players[1].Move4CD = 0;
        }

        #endregion
    }
}