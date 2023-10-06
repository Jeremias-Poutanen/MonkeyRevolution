using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float cameraPosX = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, cameraPosX, -10f);
    }
}
