using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RO
{
    public class SettingsCanvas : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void DiscordLink()
        {
            Application.OpenURL("https://discord.gg/KAtQJJs");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void PlayBotGame()
        {
            StartCoroutine(LoadAsynchronously(4));
        }

        public void GoToCardCollection()
        {
            StartCoroutine(LoadAsynchronously(5));
        }

        public void GoToMenu()
        {
            StartCoroutine(LoadAsynchronously(2));
        }

        IEnumerator LoadAsynchronously(int sceneIndex)
        {
            //var NewLoading = Instantiate(LoadingIcon);
            //NewLoading.transform.SetParent(Canvas);
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


            while (!operation.isDone)
            {

                //LoadingScript.LoadingIsHappening = true;
                //slider.value = operation.progress;

                yield return null;
            }
        }
    }
}