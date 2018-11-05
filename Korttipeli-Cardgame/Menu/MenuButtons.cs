using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

    public Säätäjä säädin;

    public Transform Spawn;

    public GameObject Angira1;
    public GameObject Angira2;

    void Awake()
    {
        säädin = GameObject.FindGameObjectWithTag("Switch").GetComponent<Säätäjä>();
    }

    public void StartLevel(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Angira()
    {
        Destroy(GameObject.FindWithTag("Character"));
        Instantiate(Angira1);
        säädin.ChosenMonster = 1;
    }

    public void AngiraSinine()
    {
        Destroy(GameObject.FindWithTag("Character"));
        Instantiate(Angira1);
        säädin.ChosenMonster = 1;
    }

    public void AngiraPunane()
    {
        Destroy(GameObject.FindWithTag("Character"));
        Instantiate(Angira2);
        säädin.ChosenMonster = 2;
    }
}
