using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RO.Muilutus
{
    public class MainMenu : MonoBehaviour
    {

        public GameObject Loading;
        public Slider slider;

        public void PlayGame(int sceneIndex)
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }

        IEnumerator LoadAsynchronously(int sceneIndex)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

            Loading.SetActive(true);

            while (!operation.isDone)
            {
                slider.value = operation.progress;

                yield return null;
            }
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}