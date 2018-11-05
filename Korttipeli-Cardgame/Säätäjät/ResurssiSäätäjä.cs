using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO
{
    [CreateAssetMenu(menuName = "Säätäjät/ResurssiSäätäjä")]
    public class ResurssiSäätäjä : ScriptableObject
    {
        public Elementti tyyppiElementti;
        public Kortti[] kaikkiKortit;
        Dictionary<string, Kortti> cardsDict = new Dictionary<string, Kortti>();

        public void Init()
        {
            cardsDict.Clear();
            for(int i = 0; i < kaikkiKortit.Length; i++)
            {
                cardsDict.Add(kaikkiKortit[i].name, kaikkiKortit[i]);
            }
        }


        public Kortti HaeKorttiInstanssi(string id)
        {
            Kortti originalCard = HaeKortti(id);
            if (originalCard == null)
                return null;

            Kortti newInst = Instantiate(originalCard);
            newInst.name = originalCard.name;
            return newInst;
        }

        Kortti HaeKortti(string id)
        {
            Kortti result = null;
            cardsDict.TryGetValue(id, out result);
            return result;
        }
    }
}