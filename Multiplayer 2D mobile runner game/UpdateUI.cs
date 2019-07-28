using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

//Author: M.J.Metsola @RisenOutcast

namespace RO
{
    public class UpdateUI : MonoBehaviour
    {
        public GameObject alku;
        public GameObject player;
        public GameObject lintu;
        public Lintu lintuScript;
        public Pelaaja playerScript;
        public TMP_Text teksti;
        public TMP_Text teksti2;
        public TMP_Text pointsText;
        CameraFollow cameraFollowi;
        public GameObject[] Hearts;

        // Start is called before the first frame update
        IEnumerator Start()
        {
            yield return new WaitForSeconds(4f);
            //if (!player)
            //player = GameObject.FindWithTag("Player");

            //if (!lintu)
            //lintu = GameObject.FindWithTag("Lintu");

            player = Pelisäätäjä.instance.PlayerScript.gameObject;
            lintu = Pelisäätäjä.instance.LintuScript.gameObject;

            cameraFollowi = Camera.main.GetComponent<CameraFollow>();
            lintuScript = Pelisäätäjä.instance.LintuScript;
            playerScript = Pelisäätäjä.instance.PlayerScript;

        }

        // Update is called once per frame
        void Update()
        {
            teksti.text = ("Distance traveled: " + Mathf.RoundToInt(Vector3.Distance(alku.transform.position, player.transform.position)).ToString() + "m");

            teksti2.text = ("Distance to Bird: " + Mathf.RoundToInt(lintuScript.distanceToPlayer) + "m");

            if (Pelisäätäjä.instance.isOverlord)
                pointsText.text = ("Score: " + playerScript.Points.ToString());
            else
                pointsText.text = ("Score: " + lintuScript.Points.ToString());

            for (int i = 0; i < Hearts.Length; i++)
            {
                if (i > (playerScript.Health - 1))
                {
                    Hearts[i].SetActive(false);
                }
                else
                {
                    Hearts[i].SetActive(true);
                }
            }

        }
    }
}