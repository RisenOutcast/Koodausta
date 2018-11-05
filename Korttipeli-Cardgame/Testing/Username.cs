using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;
using UnityEngine.SceneManagement;

public class Username : MonoBehaviour {

    string currentplayer;

    //public TMP_InputField username;
    //public TextMeshProUGUI Hello;

    //public Text Hello;


	// Use this for initialization
	void Start () {
		
	}

    public void SetName()
    {
        //PlayerPrefs.SetString("Currentplayer", username.text);

    }

    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Save()
    {
        //PlayerPrefs.Save;
    }

    // Update is called once per frame
    void Update () {
        
    }
}