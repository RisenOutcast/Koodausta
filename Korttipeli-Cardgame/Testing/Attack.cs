using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public Monster monster1;
    public Monster monster2;

    public float AttackPower;
    public float EnemyDefenceScale;
    public int DamageToArmor;

    // Use this for initialization
    void Start () {
	}

    public void Attack1()
    {
        monster2.health -= AttackPower;

        if (monster2.defence > 0)
        {
            monster2.defence -= DamageToArmor;
        }
    }

    // Update is called once per frame
    void Update () {
        EnemyDefenceScale = (float)0.0 + (monster2.defence);
        AttackPower = (monster1.attack - EnemyDefenceScale);

        if (monster2.defence > 0)
        {
            DamageToArmor = (int)AttackPower / (int)EnemyDefenceScale;
        }
    }
}
