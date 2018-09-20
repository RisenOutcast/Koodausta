using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RO.Muilutus
{
    public class TitleScreen : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.anyKey)
                SceneManager.LoadScene("MuilutusMenu");

        }
    }
}