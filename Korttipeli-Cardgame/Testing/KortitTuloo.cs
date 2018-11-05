using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KortitTuloo : MonoBehaviour {

    Animator anim;
    public GameObject CardsButton;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void KortitEsiin()
    {
        anim.SetBool("In", true);
    }

    public void KortitPiiloon()
    {
        anim.SetBool("In", false);
    }

    public void NäppäinEsiin()
    {
        CardsButton.SetActive(true);
    }

    public void NäppäinPiiloon()
    {
        CardsButton.SetActive(false);
    }
}
