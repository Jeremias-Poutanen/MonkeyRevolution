using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int health = 3;

    public GameObject GameOverScreen;
    

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
    }
    void GameOver()
    {
        Time.timeScale = 0;

        GameOverScreen.SetActive(true);
    }

}
