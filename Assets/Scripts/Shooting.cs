using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    PlayerController playerController;
    float direction = 1f;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        if(!playerController.facingRight)
        {
            direction *= -1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      //  Debug.Log("We got hit by: " + collision.name);

        //Destroy projectile on hit
        if(collision.collider.tag == "Ground" || collision.collider.tag == "Enemy")
        {
            Destroy(gameObject);           
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction, 0, 0) * speed * Time.deltaTime;
    }
}
    