using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CatalystKortti")]
public class CatalystKortti : ScriptableObject
{
    public string cost;
    public new string name;
    public string description;
    public string cardnumber;
    public Sprite kuva;

    public int addmaxhealth;
    public int addhealth;
    public int addattack;
    public int adddefence;


}