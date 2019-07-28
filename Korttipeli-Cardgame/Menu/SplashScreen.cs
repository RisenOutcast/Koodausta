using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace RO.Menus {
    public class SplashScreen : MonoBehaviour {

        public GameObject LoadingIcon;
        public RO.Loading.LoadingIcon LoadingScript;
        public Transform Canvas;

        Mestarisäätäjä Mestari;

        public TMP_Text DevText;

        int activateCount = 0;

        // Use this for initialization
        void Start() {
            Mestari = GameObject.FindWithTag("Mestari").GetComponent<Mestarisäätäjä>();
        }

        public void PlayGame(int sceneIndex)
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }

        IEnumerator LoadAsynchronously(int sceneIndex)
        {
            var NewLoading = Instantiate(LoadingIcon);
            NewLoading.transform.SetParent(Canvas);
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


            while (!operation.isDone)
            {

                LoadingScript.LoadingIsHappening = true;
                //slider.value = operation.progress;

                yield return null;
            }
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown("o"))
            {
                activateCount += 1;
            }

            if (activateCount > 3)
            {
                Mestari.DevMode = true;
                DevText.text = "DevMode Activated";
            }
        }
    }
}