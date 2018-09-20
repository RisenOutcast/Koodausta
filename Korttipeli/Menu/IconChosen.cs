using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconChosen : MonoBehaviour {

    public GameObject CrossMark;

    public void Chosen()
    {
        CrossMark.SetActive(true);
    }
}
