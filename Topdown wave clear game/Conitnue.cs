using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RO.Crab
{
    public class Conitnue : MonoBehaviour
    {
        public void ContinueButton()
        {
            Master.instance.points -= 1500;
            Master.instance.Playerhealth = 50;
            if(Master.instance.bossKeyObtained)
                Master.instance.waveCount -= 1;
            SceneManager.LoadScene("CrabHub");
        }
    }
}