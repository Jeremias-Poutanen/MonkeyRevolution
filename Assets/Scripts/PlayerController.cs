using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float jumpForce = 16f;
    [SerializeField] float speed = 300f;
    [SerializeField] float gravityMultiplier = 5;
    float horizontalValue;
    

    void Start()
    {
        Physics2D.gravity *= gravityMultiplier; 
    }

    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space)) 
        { 
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            //isOnGround = false;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float xVal = horizontalValue * speed * Time.deltaTime;
        Vector2 targetVelocity = new Vector2(xVal, playerRb.velocity.y);
        playerRb.velocity = targetVelocity;
    }
}

