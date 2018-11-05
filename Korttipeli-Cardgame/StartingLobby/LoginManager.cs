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

        public string savedUsername;
        public bool Connecting;

        private string OldAlert;

        void Awake()
        {
            savedUsername = PlayerPrefs.GetString("Username");
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

            if(PasswordsMatch == true && RegisterTab.activeSelf == true)
            {
                AlertText = "";
                AlertColor = new Color32(255, 255, 255, 255);
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
                Debug.Log("Saving...");
            }
            else
            {
                DeleteUsername();
                Debug.Log("Deleting...");
            }
            AlertText = "Connecting";
            AlertColor = new Color32(0, 160, 255, 255);
            Connecting = true;
            StartCoroutine(RollDotsOnText()); //Jos tulee joku virhe esim. pelaajaa ei löydy niin pistää vaan StopCoroutine...
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

        IEnumerator RollDotsOnText()
        {
            OldAlert = AlertText;
            yield return new WaitForSeconds(0.2F);
            if (Connecting == true)
            {
                AlertText = (AlertText + ".");
                SetAlert();
            }
            yield return new WaitForSeconds(0.2F);
            if (Connecting == true)
            {
                AlertText = (AlertText + ".");
                SetAlert();
            }
            yield return new WaitForSeconds(0.2F);
            if (Connecting == true)
            {
                AlertText = (AlertText + ".");
                SetAlert();
            }
            yield return new WaitForSeconds(0.2F);
            if(Connecting == true)
            {
                AlertText = OldAlert;
                StartCoroutine(RollDotsOnText());
            }
        }
    }
}