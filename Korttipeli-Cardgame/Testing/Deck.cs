using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public PakanSäätäjä säädin;

    public GameObject[] Cards;

    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;

    Transform _deck;

    // Use this for initialization
    void Start () {
        säädin = GameObject.FindGameObjectWithTag("Switch").GetComponent<PakanSäätäjä>();
        _deck = this.transform;

        if (säädin.D1CardID1 > 0)
        {
            Instantiate(Card1, _deck.position, Quaternion.identity, transform);
        }
        if (säädin.D1CardID2 > 0)
        {
            Instantiate(Card2, _deck.position, Quaternion.identity, transform);
        }
        if (säädin.D1CardID3 > 0)
        {
            Instantiate(Card3, _deck.position, Quaternion.identity, transform);
        }
        if (säädin.D1CardID4 > 0)
        {
            Instantiate(Card4, _deck.position, Quaternion.identity, transform);
        }
        if (säädin.D1CardID5 > 0)
        {
            Instantiate(Card5, _deck.position, Quaternion.identity, transform);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
