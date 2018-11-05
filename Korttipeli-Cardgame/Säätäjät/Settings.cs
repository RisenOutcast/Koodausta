using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RO
{
    public static class Settings
    {
        public static PeliSäätäjä peliSäätäjä;
        private static ResurssiSäätäjä _resurssiSäätäjä;
        private static RO.Konsoli.KonsoliHook _konsoliManageri;

        public static void RegisterEvent(string e, Color color)
        {
            if(_konsoliManageri == null)
            {
                _konsoliManageri = Resources.Load("KonsoliHook") as RO.Konsoli.KonsoliHook;
            }

            _konsoliManageri.RegisterEvent(e, color);
        }

        public static ResurssiSäätäjä GetResurssiSäätäjä()
        {
            if(_resurssiSäätäjä == null)
            {
                _resurssiSäätäjä = Resources.Load("ResurssiSäätäjä") as ResurssiSäätäjä;
                _resurssiSäätäjä.Init();
            }

            return _resurssiSäätäjä;
        }

        public static List<RaycastResult> GetUiObjs()
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);
            return results;
        }

        public static void DropCatalystCard(Transform c, Transform p, KorttiInstanssi korttiInst)
        {
            SetParentForCard(c, p);
            peliSäätäjä.currentPlayer.UseCoinCards(korttiInst.asentaja.kortti.Hinta);
            peliSäätäjä.currentPlayer.DropCard(korttiInst);
        }

        public static void DropStatCard(Transform c, Transform p, KorttiInstanssi korttiInst)
        {
            SetParentForCard(c, p);
            peliSäätäjä.currentPlayer.DropCard(korttiInst);
        }

        public static void DropMinionCard(Transform c, Transform p, KorttiInstanssi korttiInst)
        {
            SetParentForCard(c, p);
            peliSäätäjä.currentPlayer.DropCard(korttiInst);
        }

        public static void SetParentForCard(Transform c, Transform p)
        {
            c.SetParent(p);
            c.localPosition = Vector3.zero;
            c.localEulerAngles = Vector3.zero;
            c.localScale = new Vector3(0.7F, 0.7F, 0.7F);
        }
    }
}