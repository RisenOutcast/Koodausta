using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    [CreateAssetMenu (menuName = "Alueet/OmatKortitPöydälläKunRaahaaKorttia")]
    public class OmienPöytäKorttienLogiikka : AlueLogiikka
    {
        public KorttiVariable kortti;
        public KorttiTyyppi stattiTyyppi;
        public KorttiTyyppi minioniTyyppi;
        public KorttiTyyppi kolikkoTyyppi;
        public KorttiTyyppi catalystTyyppi;
        public RO.TransformiVariable alueGridi;
        public RO.TransformiVariable minioniGridi;
        public RO.TransformiVariable rahaGridi;
        public GameElements.GameElementLogic korttipöydälle;

        public override void Execute()
        {
            if (kortti.value == null)
                return;

            Kortti k = kortti.value.asentaja.kortti;

            if(k.korttiTyyppi == stattiTyyppi)
            {
                bool canUse = Settings.peliSäätäjä.currentPlayer.CanUseCard(k);

                if (canUse)
                {
                    //Pistä kortti pöydälle
                    Settings.DropStatCard(kortti.value.transform, alueGridi.value.transform,
                        kortti.value);
                    kortti.value.currentLogic = korttipöydälle;
                    //Settings.peliSäätäjä.currentPlayer.kortitKädes.RemoveAt(1);

                    Settings.peliSäätäjä.all_players[0].MonsterHealth += k.AddHealth;
                    Settings.peliSäätäjä.all_players[0].MonsterAttack += k.AddAttack;
                    Settings.peliSäätäjä.all_players[0].MonsterDefence += k.AddDefence;
                    Settings.peliSäätäjä.all_players[0].MonsterArmor += k.AddArmor;
                    Settings.peliSäätäjä.all_players[0].MonsterImpact += k.AddImpact;
                    Settings.peliSäätäjä.all_players[0].MonsterPierce += k.AddPierce;
                    Settings.peliSäätäjä.all_players[1].MonsterHealth -= k.TakeHealth;
                    Settings.peliSäätäjä.all_players[1].MonsterDefence -= k.TakeDefence;
                    Settings.peliSäätäjä.all_players[1].MonsterAttack -= k.TakeAttack;

                    if (k.Death == true)
                    {
                        Settings.peliSäätäjä.all_players[0].Minion1Health = k.AddMinionHealth;
                        Settings.peliSäätäjä.all_players[0].Minion2Health = k.AddMinionHealth;
                        Settings.peliSäätäjä.all_players[0].Minion3Health = k.AddMinionHealth;
                        Settings.peliSäätäjä.all_players[0].Minion4Health = k.AddMinionHealth;
                    }
                }

                kortti.value.gameObject.SetActive(true);
            }
            else
            if (k.korttiTyyppi == minioniTyyppi)
            {
                bool canUse = Settings.peliSäätäjä.currentPlayer.CanUseCard(k);

                if (canUse)
                {
                    //Pistä kortti pöydälle
                    Settings.DropMinionCard(kortti.value.transform, minioniGridi.value.transform,
                        kortti.value);
                    kortti.value.currentLogic = korttipöydälle;
                    Settings.peliSäätäjä.all_players[0].hasActiveMinions = true;
                    Settings.peliSäätäjä.all_players[0].PhasAmount = k.AddPhas;
                    Settings.peliSäätäjä.all_players[0].AbasAmount = k.AddAbas;
                    Settings.peliSäätäjä.all_players[0].TygoAmount = k.AddTygo;
                    Settings.peliSäätäjä.all_players[0].Minion1Health = k.AddMinionHealth;
                    Settings.peliSäätäjä.all_players[0].Minion2Health = k.AddMinionHealth;
                    Settings.peliSäätäjä.all_players[0].Minion3Health = k.AddMinionHealth;
                    Settings.peliSäätäjä.all_players[0].Minion4Health = k.AddMinionHealth;
                }

                kortti.value.gameObject.SetActive(true);
                
            }
            else
            if (k.korttiTyyppi == kolikkoTyyppi)
            {
                //Pistä kortti pöydälle
                bool canUse = Settings.peliSäätäjä.currentPlayer.CanUseCard(k);

                if (canUse)
                {
                    Settings.SetParentForCard(kortti.value.transform, rahaGridi.value.transform);
                    kortti.value.currentLogic = korttipöydälle;
                    Settings.peliSäätäjä.currentPlayer.AddCoinCard(kortti.value.gameObject);
                }
                kortti.value.gameObject.SetActive(true);
            }
            else
            if (k.korttiTyyppi == catalystTyyppi)
            {
                bool canUse = Settings.peliSäätäjä.currentPlayer.CanUseCard(k);

                if (canUse)
                {
                    Settings.DropCatalystCard(kortti.value.transform, alueGridi.value.transform,
                        kortti.value);

                    kortti.value.currentLogic = korttipöydälle;
                }

                kortti.value.gameObject.SetActive(true);
            }

            //Alla pätkä jolla voi lisätä *lompakkoon kolikkokortin.
            //*eli siis siihen listaan joka listautuu koodissa itsessään
            //Settings.peliSäätäjä.currentPlayer.AddCoinCard(kortti.value.gameObject); 
        }
    }
}