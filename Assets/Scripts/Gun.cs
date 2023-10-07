using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject Projectile;
    [SerializeField] float spawnOffset = 2;
    float actualOffset;
    PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerController.hasGun)
        {
            if(!playerController.facingRight)
            {
                actualOffset = spawnOffset * -1;
            }
            else
            {
                actualOffset = spawnOffset;
            }
            
            //Ammutaan projektiili
            Instantiate(Projectile, transform.position + new Vector3(actualOffset, 0.5f, 0), Projectile.transform.rotation);
        }
    }
}
