using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsController : MonoBehaviour
{
    [SerializeField] Collider2D[] boundsCollider;
    [SerializeField] GameObject respawnPoint;
    PlayerController playerController;
    GameManager gameManager;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Player")
        {
            playerController.transform.position = respawnPoint.transform.position;
            gameManager.TakeDamage();
        }
    }
}
