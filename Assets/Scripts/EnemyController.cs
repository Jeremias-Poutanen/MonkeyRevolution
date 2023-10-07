using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Rigidbody2D enemyRb;
    [SerializeField] GameObject enemySprite;
    [SerializeField] float speed = 300f;
    [SerializeField] float changeDirSpeed = 3;
    [SerializeField] float enemyDir = -1f;
    [SerializeField] float spriteOffsetX = 0f;
    [SerializeField] float spriteOffsetY = 0f;
    IEnumerator coroutine;
    

    void Start()
    {
        coroutine = ChangeDirection(changeDirSpeed);
        StartCoroutine(coroutine);
    }

    void FixedUpdate()
    {
        MoveEnemy();

        if(enemyDir > 0)
        {
            enemySprite.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        if(enemyDir < 0)
        {
            enemySprite.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }

    void MoveEnemy()
    {
            float xVal = enemyDir * speed * Time.deltaTime;
            Vector2 targetVelocity = new Vector2(xVal, enemyRb.velocity.y);
            enemyRb.velocity = targetVelocity;

            enemySprite.transform.position =  new Vector3(enemyRb.transform.position.x + spriteOffsetX, enemyRb.transform.position.y + spriteOffsetY, enemyRb.transform.position.z);
    }

    IEnumerator ChangeDirection(float changeDirSpeed)
    {
        while (true)
        {
            enemyDir *= -1;
            spriteOffsetX *= -1;

            yield return new WaitForSeconds(changeDirSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.collider.tag == "Player")
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
