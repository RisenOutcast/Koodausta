using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: M.J.Metsola @RisenOutcast

namespace RO
{
    public class ShowCorrectView : MonoBehaviour
    {
        public GameObject RunnerCanvas;
        public GameObject OverlordCanvas;

        public GameObject RunnerCamera;
        public GameObject OverlordCamera;

        // Start is called before the first frame update
        void Start()
        {
            if (Pelisäätäjä.instance.isOverlord)
            {
                RunnerCanvas.SetActive(false);
                OverlordCanvas.SetActive(true);
            }
            else
            {
                RunnerCanvas.SetActive(true);
                OverlordCanvas.SetActive(false);
            }

        }

        // Update is called once per frame
        void Update()
        {

            if (Pelisäätäjä.instance.isOverlord)
            {
                RunnerCanvas.SetActive(false);
                //RunnerCamera.SetActive(false);
                OverlordCanvas.SetActive(true);
                //OverlordCamera.SetActive(true);
            }
            else
            {
                RunnerCanvas.SetActive(true);
                //RunnerCamera.SetActive(true);
                OverlordCanvas.SetActive(false);
                //OverlordCamera.SetActive(false);
            }
        }
    }
}