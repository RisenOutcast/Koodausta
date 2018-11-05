using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour {

    public float health;
    public int attack;
    public int defence;
    public float maxhealth;

    public int maxdefence;
    public int mindefence;

    public Text H;
    public Text A;
    public Text D;

    public Slider Healthbar;
    public Slider Damagebar;
    public float CurrentHealth;
    public float Damages;
    public int Helttiintti;

    public bool DamagebarCanDecrease;

    public float LastHealth;
    

    // Use this for initialization
    void Start () {
        StartCoroutine("FixNumbers");
    }
	
	// Update is called once per frame
	void Update () {

        H.text = Helttiintti.ToString() + "/" + maxhealth;
        A.text = attack.ToString();
        D.text = defence.ToString();
        CurrentHealth = health;
        Healthbar.value = CurrentHealth;
        Healthbar.maxValue = maxhealth;
        Helttiintti = (int)CurrentHealth;
        Damagebar.value = Damages;
        Damagebar.maxValue = maxhealth;

        if(CurrentHealth < LastHealth)
        {
            BuutifulHealthDecrease();
        }

        if (defence > maxdefence)
        {
            defence = maxdefence;
        }

        if (defence < mindefence)
        {
            defence = mindefence;
        }

        if (Damages > CurrentHealth)
        {
            Damages -= 10;
        }
        else
        {
            Damages = CurrentHealth;
            DamagebarCanDecrease = false;
        }
    }

    IEnumerator CooldHealthDrop()
    {
        yield return new WaitForSeconds(2f);
        DamagebarCanDecrease = true;
    }

    IEnumerator FixNumbers()
    {
        yield return new WaitForSeconds(1f);
        LastHealth = CurrentHealth;
        Damages = CurrentHealth;
        DamagebarCanDecrease = false;
    }

    void BuutifulHealthDecrease()
    {
        StartCoroutine("CooldHealthDrop");
        LastHealth = CurrentHealth;
    }
}
