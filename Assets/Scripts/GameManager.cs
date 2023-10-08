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
    bool isImmune = false;
    

    void Start()
    {
        Time.timeScale = 1;
    }

    public void TakeDamage(int damage)
    {
        if(isImmune)
        {
            return;
        }

        health -= damage;
        isImmune = true;
        Invoke("DisableDamageImmunity", 1f);

        if(health <= 0)
        {
            GameOver();
        }

        healtText.text = health.ToString();
    }
    public void GameOver()
    {
        Time.timeScale = 0;

        GameOverScreen.SetActive(true);
    }

    public void Victory()
    {
        Time.timeScale = 0;
        VictoryScreen.SetActive(true);
    }

    void DisableDamageImmunity()
    {
        isImmune = false;
    }
}
