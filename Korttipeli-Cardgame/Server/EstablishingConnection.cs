using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EstablishingConnection : MonoBehaviour
{
    public TMP_Text Notify;
    public string WebText;

    Animator anim;

    public string dbURL = "http://risenoutcast.hopto.org/RO_Database/ConnectionTest.php";

    Mestarisäätäjä Mestari;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        if (Mestari == null)
            Mestari = GameObject.FindWithTag("Mestari").GetComponent<Mestarisäätäjä>();
        if (Mestari.DevMode == true)
        {
            dbURL = "http://192.168.8.101/RO_Database/ConnectionTest.php";
            StartCoroutine(ConnectToDatabase());
        }
        else
        {
            StartCoroutine(ConnectToDatabase());
        }

    }

    void Update()
    {
        if (Mestari == null)
            Mestari = GameObject.FindWithTag("Mestari").GetComponent<Mestarisäätäjä>();

        if (Mestari.DevMode == true)
        {
            dbURL = "http://192.168.8.101/RO_Database/ConnectionTest.php";
        }
    }

    // Update is called once per frame
    void CheckConnection()
    {

        if (Notify.text == "Connected!")
        {
            anim.SetBool("ConnectionOK", true);
            Debug.Log("All Good");
        }
        else
        {
            Notify.text = "Connection error";
        }
    }

    public IEnumerator LoadMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Lobby");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator ConnectToDatabase()
    {
        WWWForm form = new WWWForm();

        WWW www = new WWW(dbURL);

        yield return www;

        Debug.Log(www.text);
        Notify.text = www.text;
        CheckConnection();
    }
}