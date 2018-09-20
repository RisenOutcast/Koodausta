using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

    public string inputUsername;
    public string inputPassword;

    public Text usernamefield;
    public InputField passwordfield;

    public Text Notify;


    string LoginURL = "http://localhost/Tharijas/Login.php";

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        inputUsername = usernamefield.text;
        inputPassword = passwordfield.text;

        if(Notify.text == "login success")
        {
            StartCoroutine(LoadMenu());
        }
    }

    public void LoginButton()
    {
        StartCoroutine(LoginToDB(inputUsername, inputPassword));
    }

    IEnumerator LoadMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoginToDB(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        WWW www = new WWW(LoginURL, form);

        yield return www;

        Debug.Log(www.text);
        Notify.text = www.text;
    }
}
