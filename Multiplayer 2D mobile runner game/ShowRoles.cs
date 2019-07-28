using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

//Author: M.J.Metsola @RisenOutcast

namespace RO
{
    public class ShowRoles : MonoBehaviour
    {
        public TMP_Text RunnerName;
        public TMP_Text OverlordName;
        public TMP_Text Title;
        public TMP_Text CountdownText;

        // Start is called before the first frame update
        void Start()
        {
            if ((int)PhotonNetwork.LocalPlayer.CustomProperties["isRunner"] == 1)
            {
                Pelisäätäjä.instance.isOverlord = false;
                Title.text = "You are the Runner";
            }
            else
            {
                Pelisäätäjä.instance.isOverlord = true;
                Title.text = "You are the Overlord";
            }
            StartCoroutine(Countdown());
        }

        // Update is called once per frame
        void Update()
        {

            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if ((int)player.CustomProperties["isRunner"] == 1)
                {
                    Debug.Log(player.NickName + " isRunner");
                    RunnerName.text = player.NickName;
                }
                else
                {
                    Debug.Log(player.NickName + " is not Runner");
                    OverlordName.text = player.NickName;
                }
            }
        }

        public IEnumerator Countdown()
        {
            yield return new WaitForSecondsRealtime(2);
            CountdownText.text = "5";
            yield return new WaitForSecondsRealtime(1);
            CountdownText.text = "4";
            yield return new WaitForSecondsRealtime(1);
            CountdownText.text = "3";
            yield return new WaitForSecondsRealtime(1);
            CountdownText.text = "2";
            yield return new WaitForSecondsRealtime(1);
            CountdownText.text = "1";
            yield return new WaitForSecondsRealtime(1);
            CountdownText.text = "0";
            if(PhotonNetwork.IsMasterClient)
                PhotonNetwork.LoadLevel("Game");
        }
    }
}