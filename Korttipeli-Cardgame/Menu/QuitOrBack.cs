using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitOrBack : MonoBehaviour {

    string goToSceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "CardCollection")
        {
            goToSceneName = "3dMainMenu";
        }


    }
}
