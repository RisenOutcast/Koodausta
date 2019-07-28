using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDetailButton : MonoBehaviour {

    public GameObject MonsterDetails;

    public void PressButton()
    {
        if (MonsterDetails.activeSelf)
        {
            MonsterDetails.SetActive(false);
        }
        else
        {
            MonsterDetails.SetActive(true);
        }
    }
}
