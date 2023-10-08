using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    PlayerController playerController;
    BossController bossController;
    EnemyController enemyController;
    float direction = 1f;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        bossController = FindObjectOfType<BossController>();
        enemyController = FindObjectOfType<EnemyController>();

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

        if(collision.collider.tag == "Enemy")
        {
            Destroy(gameObject);
            enemyController.DoEnemyDamage();
        }

        if(collision.collider.tag == "Boss")
        {
            bossController.DoDamage();
            Destroy(gameObject);  
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Boss")
        {
            Debug.Log("hit");
            bossController.DoDamage();
            Destroy(gameObject);  
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction, 0, 0) * speed * Time.deltaTime;
    }
}
    