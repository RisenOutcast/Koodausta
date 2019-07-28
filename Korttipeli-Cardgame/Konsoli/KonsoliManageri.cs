using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RO.Konsoli
{
    public class KonsoliManageri : MonoBehaviour
    {
        public Transform konsoliGridi;
        public GameObject prefab;
        TMP_Text[] textObjects;
        int index;

        public KonsoliHook hook;

        private void Awake()
        {
            hook.konsoliManageri = this;

            textObjects = new TMP_Text[13];
            for (int i = 0; i < textObjects.Length; i++)
            {
                GameObject go = Instantiate(prefab) as GameObject;
                textObjects[i] = go.GetComponent<TMP_Text>();
                go.transform.SetParent(konsoliGridi);
            }
        }

        public void RegisterEvent(string s, Color color)
        {
            index++;
            if (index == textObjects.Length)
            {
                index = 0;
            }

            textObjects[index].color = color;
            textObjects[index].text = s;
            textObjects[index].gameObject.SetActive(true);
            textObjects[index].transform.SetAsLastSibling();
        }
    }
}