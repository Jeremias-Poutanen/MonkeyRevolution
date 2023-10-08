using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int health = 3;

    public GameObject GameOverScreen;
    [SerializeField] TMP_Text healtText;
    public GameObject VictoryScreen;
    

    void Start()
    {
        Time.timeScale = 1;
    }

    public void TakeDamage()
    {
        health--;

        if(health <= 0)
        {
            GameOver();
        }

        healtText.text = health.ToString();

    }
    void GameOver()
    {
        Time.timeScale = 0;

        GameOverScreen.SetActive(true);
    }

    void Victory()
    {
        VictoryScreen.SetActive(true);
    }
}
