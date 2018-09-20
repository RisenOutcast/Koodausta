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
                //Pistä kortti pöydälle
                Settings.DropStatCard(kortti.value.transform, alueGridi.value.transform,
                        kortti.value);
                kortti.value.gameObject.SetActive(true);
                kortti.value.currentLogic = korttipöydälle;
            }
            else
            if (k.korttiTyyppi == minioniTyyppi)
            {
                //Pistä kortti pöydälle
                Settings.DropMinionCard(kortti.value.transform, minioniGridi.value.transform,
                        kortti.value);
                kortti.value.gameObject.SetActive(true);
                kortti.value.currentLogic = korttipöydälle;
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