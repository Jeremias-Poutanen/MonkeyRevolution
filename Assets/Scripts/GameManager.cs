using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int health = 3;

    public void TakeDamage()
    {
        health--;
    }

    //void GameOver() ???
}
