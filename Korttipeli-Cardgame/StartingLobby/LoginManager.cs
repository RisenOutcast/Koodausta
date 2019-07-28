using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RO.Login
{
    public class LoginManager : MonoBehaviour
    {

        public TMP_InputField UsernameUI;
        public TMP_InputField PasswordUI;
        public TMP_InputField RegisterUsernameUI;
        public TMP_InputField RegisterPasswordUI;
        public TMP_InputField ReEnterPasswordUI;
        public TMP_InputField EmailAddressUI;

        public string UsernameString;
        public string PasswordString;
        public string RegisterUsernameString;
        public string RegisterPasswordString;
        public string ReEnterPasswordString;
        public string EmailAddressString;

        public Toggle SaveUsernameToggle;

        public bool PasswordsMatch;
        public bool FieldsAreGiven;

        public TMP_Text Alerts;
        public string AlertText;
        private Color32 AlertColor; 

        public GameObject RegisterTab;
        public GameObject ConfirmButton;

        Mestarisäätäjä Mestari;

        public string savedUsername;
        public bool Connecting;

        private string OldAlert;
        public string Notify;

        public string CreateUserURL = "http://risenoutcast.hopto.org/RO_Database/InsertUser.php";
        public string FindUserURL = "http://risenoutcast.hopto.org/RO_Database/Login.php";
        public string GetUserDataURL = "http://risenoutcast.hopto.org/RO_Database/PlayerData.php";

        public string[] userInformation;

        private Animator CamAnim;
        private Animator LoginCanvasAnim;

        void Awake()
        {
            savedUsername = PlayerPrefs.GetString("Username");
            Mestari = GameObject.FindWithTag("Mestari").GetComponent<Mestarisäätäjä>();
            CamAnim = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
            LoginCanvasAnim = GameObject.FindWithTag("LoginCanvas").GetComponent<Animator>();
        }

        // Use this for initialization
        void Start()
        {
            Connecting = false;
            if(savedUsername == "")
            {
                SaveUsernameToggle.isOn = false;
            }
            else
            {
                UsernameUI.text = savedUsername;
            }
        }

        // Update is called once per frame
        void Update()
        {
            UsernameString = UsernameUI.text;
            PasswordString = PasswordUI.text;

            RegisterUsernameString = RegisterUsernameUI.text;
            RegisterPasswordString = RegisterPasswordUI.text;
            ReEnterPasswordString = ReEnterPasswordUI.text;
            EmailAddressString = EmailAddressUI.text;

            //Changing Alerts Colour
            //(WHITE) Alerts.color = new Color32(255, 255, 255, 255);
            //(RED) Alerts.color = new Color32(255, 0, 0, 255);
            //(GREEN) Alerts.color = new Color32(0, 255, 23, 255);
            //(BLUE) Alerts.color = new Color32(0, 160, 255, 255);

            if (RegisterPasswordString == ReEnterPasswordString)
            {
                PasswordsMatch = true;
            }
            else
            {
                PasswordsMatch = false;
            }

            if(RegisterUsernameString != "" && RegisterPasswordString != "" && ReEnterPasswordString != "" && EmailAddressString != "")
            {
                FieldsAreGiven = true;
            }
            else
            {
                FieldsAreGiven = false;
            }

            if(PasswordsMatch == false && RegisterPasswordString != "" || PasswordsMatch == false && ReEnterPasswordString != "")
            {
                AlertText = "Passwords do not match";
                AlertColor = new Color32(255, 0, 0, 255);
            }

            if(PasswordsMatch == true && RegisterTab.activeSelf == true && Notify == "")
            {
                AlertText = "";
                AlertColor = new Color32(255, 255, 255, 255);
            }

            if(PasswordsMatch == true && FieldsAreGiven == true)
            {
                ConfirmButton.SetActive(true);
            }
            else
            {
                ConfirmButton.SetActive(false);
            }

            if (Mestari == null)
                Mestari = GameObject.FindWithTag("Mestari").GetComponent<Mestarisäätäjä>();

            if (Mestari.DevMode == true)
            {
                CreateUserURL = "http://192.168.8.101/RO_Database/InsertUser.php";
                FindUserURL = "http://192.168.8.101/RO_Database/Login.php";
                GetUserDataURL = "http://192.168.8.101/RO_Database/PlayerData.php";
            }
        }

        void LateUpdate()
        {
            SetAlert();    
        }

        public void LogginIn()
        {
            if (SaveUsernameToggle.isOn == true)
            {
                SaveUsername();
                Debug.Log("Saving username...");
            }
            else
            {
                DeleteUsername();
                Debug.Log("Deleting saved username...");
            }
            AlertText = "Connecting";
            AlertColor = new Color32(0, 160, 255, 255);
            Connecting = true;
            StartCoroutine(Login(UsernameString, PasswordString));
        }

        void GetSavedUsername()
        {
            UsernameUI.text = PlayerPrefs.GetString("Username", null);
        }

        void SaveUsername()
        {
            PlayerPrefs.SetString("Username", UsernameString);
        }

        void DeleteUsername()
        {
            PlayerPrefs.DeleteKey("Username");
        }

        void SetAlert()
        {
            Alerts.text = AlertText;
            Alerts.color = AlertColor;
        }

        public void ClearAlerts()
        {
            Alerts.text = "";
            Alerts.color = new Color32(255, 255, 255, 255);
        }

        public void MakeUser()
        {
            StartCoroutine(CreateUser(RegisterUsernameString, EmailAddressString, RegisterPasswordString));
        }

        IEnumerator Login(string username, string password)
        {
            WWWForm form = new WWWForm();
            form.AddField("usernamePost", username);
            form.AddField("passwordPost", password);

            WWW www = new WWW(FindUserURL, form);

            yield return www;
            Debug.Log(www.text);
            Notify = www.text;
            Alerts.text = www.text;
            AlertText = www.text;
            if (www.text == "Login successful!")
            {
                StartCoroutine(FetchUserData(UsernameString));
                Mestari.Playername = username;
            }
        }

        IEnumerator CreateUser(string username, string email, string password)
        {
            WWWForm form = new WWWForm();
            form.AddField("usernamePost", username);
            form.AddField("emailPost", email);
            form.AddField("passwordPost", password);

            Debug.Log("Sending " + username + "," + email + "," + password);

            WWW www = new WWW(CreateUserURL, form);

            yield return www;

            Debug.Log(www.text);
            Notify = www.text;
            Alerts.text = www.text;
            AlertText = www.text;
        }

        IEnumerator FetchUserData(string username)
        {
            WWWForm form = new WWWForm();
            form.AddField("usernamePost", username);
            WWW userData = new WWW(GetUserDataURL, form);
            yield return userData;
            string userDatastring = userData.text;
            userInformation = userDatastring.Split(';');
            Mestari.PlayerID = UserDataValues(userInformation[0], "ID:");
            Mestari.Email = UserDataValues(userInformation[0], "Email:");
            Mestari.EmailVerified = UserDataValues(userInformation[0], "Verified:");
            Mestari.Birthday = UserDataValues(userInformation[0], "Birth:");
            Mestari.Sex = UserDataValues(userInformation[0], "Sex:");
            Mestari.Nickname = UserDataValues(userInformation[0], "Nickname:");
            Mestari.Country = UserDataValues(userInformation[0], "Country:");
            Mestari.IconID = UserDataValues(userInformation[0], "IconID:");
            Mestari.UserSince = UserDataValues(userInformation[0], "UserSince:");
            Mestari.Dev = UserDataValues(userInformation[0], "IsDev:");
            CamAnim.SetBool("loginSuccesful", true);
            LoginCanvasAnim.SetBool("LoginSuccesful", true);
        }

        string UserDataValues(string data, string index)
        {
            string value = data.Substring(data.IndexOf(index) + index.Length);
            value = value.Remove(value.IndexOf("|"));
            return value;
        }
    }
}