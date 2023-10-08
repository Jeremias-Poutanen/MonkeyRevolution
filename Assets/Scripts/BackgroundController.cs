using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] float cameraPosY = 13f;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if(!playerController.inBossRoom)
        {
            transform.position = new Vector3(playerController.transform.position.x / 2, cameraPosY, 30);
        }
    }
}
