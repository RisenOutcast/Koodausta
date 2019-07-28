using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataInserter : MonoBehaviour {

	public string inputUserName;
	public string inputPassword;
	public string inputEmail;

    public InputField username;
    public InputField password;
    public InputField Repassword;
    public InputField email;

    public Text passnotmatch;
    public bool passmatch;
    public bool allgood;

    public Text Notify;

    public GameObject Registerbutton;

    public GameObject RegisterArea;
    public GameObject SuccessArea;

    string CreateUserURL = "http://risenoutcast.hopto.org/RO_Database/InsertUser.php";

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {

        inputUserName = username.text;
        inputPassword = password.text;
        inputEmail = email.text;


        if(Notify.text == "Success!")
        {
            SuccessArea.SetActive(true);
            RegisterArea.SetActive(false);
            Notify.text = " ";
        }
	}

    public void MakeUser()
    {
        StartCoroutine(CreateUser(inputUserName, inputPassword, inputEmail));
    }

    IEnumerator CreateUser(string username, string password, string email){
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", username);
		form.AddField("emailPost", email);
		form.AddField("passwordPost", password);

		WWW www = new WWW(CreateUserURL, form);

        yield return www;

        Debug.Log(www.text);
        Notify.text = www.text;
    }
}
