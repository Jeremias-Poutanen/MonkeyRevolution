using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject playerSprite;
    [SerializeField] GameObject gunSprite;
    [SerializeField] GameObject bossRoomDoor;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject bossSpawner;
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float jumpForce = 16f;
    [SerializeField] float speed = 300f;
    [SerializeField] float gravityMultiplier = 5;
    [SerializeField] float spriteOffsetY = 0f;
    [SerializeField] float spriteOffsetX = 0f;
    [SerializeField] float gunSpriteOffsetY = 0f;
    [SerializeField] float gunSpriteOffsetX = 0f;
    float horizontalValue;
    bool isGrounded = true;
    bool doubleJump = false;
    public bool facingRight = true;
    public bool hasGun = false;
    public bool inBossRoom = false;
    CameraController cameraController;
    

    void Start()
    {
        Physics2D.gravity = new Vector2(0, -9.81f);
        Physics2D.gravity *= gravityMultiplier; 
        cameraController = FindObjectOfType<CameraController>();
    }

    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.W) && isGrounded && doubleJump) 
        { 
            playerRb.velocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if(Input.GetKeyDown(KeyCode.W) && isGrounded) 
        { 
            playerRb.velocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            doubleJump = true;
        }

        if(horizontalValue > 0)
        {
            facingRight = true;
            playerSprite.transform.rotation = new Quaternion(0, 0, 0, 0);
            gunSprite.transform.rotation = new Quaternion(0, 0, 0, 0);

            if(gunSpriteOffsetX < 0)
            {
                gunSpriteOffsetX *= -1;
            }
        }

        if(horizontalValue < 0)
        {
            facingRight = false;
            playerSprite.transform.rotation = new Quaternion(0, 180, 0, 0);
            gunSprite.transform.rotation = new Quaternion(0, 180, 0, 0);

            if(gunSpriteOffsetX > 0)
            {
                gunSpriteOffsetX *= -1;
            }
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

        playerSprite.transform.position =  new Vector3(playerRb.transform.position.x + spriteOffsetX, playerRb.transform.position.y + spriteOffsetY, playerRb.transform.position.z);
        gunSprite.transform.position =  new Vector3(playerRb.transform.position.x + gunSpriteOffsetX, playerRb.transform.position.y + gunSpriteOffsetY, playerRb.transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Ground")
        {
            isGrounded = true;
            doubleJump = false;
        }

        if(collider2D.tag == "Gun")
        {
            hasGun = true;
            gunSprite.SetActive(true);
            Destroy(collider2D.gameObject);
        }

        if(collider2D.tag == "BossRoom")
        {
            inBossRoom = true;
            cameraController.BossRoomCamera();
            bossRoomDoor.SetActive(true);
            boss.SetActive(true);
            bossSpawner.SetActive(true);
        }
    }
}

