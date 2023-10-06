using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject playerController;
    [SerializeField] float cameraPosY = 3f;

    void Update()
    {
        transform.position = new Vector3(playerController.transform.position.x, cameraPosY, -10f);
    }
}
