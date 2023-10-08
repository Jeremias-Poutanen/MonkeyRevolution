using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] Camera thisCamera;
    [SerializeField] float cameraPosY = 3f;
    [SerializeField] Vector3 bossCameraPosition;

    void Start()
    {
        bossCameraPosition = new Vector3(531.5f, 38.8f, -10f);
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if(!playerController.inBossRoom)
        {
            transform.position = new Vector3(playerController.transform.position.x, cameraPosY, -10f);
        }
    }

    public void BossRoomCamera()
    {
        Debug.Log(bossCameraPosition);
        transform.position = bossCameraPosition;
        thisCamera.orthographicSize = 41f;
    }
}
