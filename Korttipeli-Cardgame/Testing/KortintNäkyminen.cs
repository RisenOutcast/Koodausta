using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class KortintNäkyminen : MonoBehaviour {

    public GameObject Cardface;
    public GameObject Cardback;
    public bool CardBackOn = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(CardBackOn == false)
        {
            Cardface.SetActive(true);
            Cardback.SetActive(false);
        }
        else
        {
            Cardface.SetActive(false);
            Cardback.SetActive(true);
        }
	}
}
