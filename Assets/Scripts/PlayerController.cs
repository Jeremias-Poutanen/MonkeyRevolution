using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float jumpForce = 16f;
    [SerializeField] float speed = 300f;
    [SerializeField] float gravityMultiplier = 5;
    float horizontalValue;
    bool isGrounded = true;
    bool doubleJump = false;
    

    void Start()
    {
        Physics2D.gravity *= gravityMultiplier; 
    }

    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && doubleJump) 
        { 
            playerRb.velocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        { 
            playerRb.velocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            doubleJump = true;
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

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Ground")
        {
            isGrounded = true;
            doubleJump = false;
        }
    }
}

