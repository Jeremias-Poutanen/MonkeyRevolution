using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    GameManager gameManager;
    IEnumerator coroutine;
    PlayerController playerController;
    [SerializeField] GameObject parentObj;
    float attackDelay = 1f;
    Vector3 target;
    float lerpDuration = 60;
    bool firstTime = true;
    int health = 30;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        gameManager = FindObjectOfType<GameManager>();

        coroutine = AttackPlayer(attackDelay);
        StartCoroutine(coroutine);
    }

    IEnumerator AttackPlayer(float attackDelay)
    {
        while(true)
        {
            if(firstTime)
            {
                firstTime = false;
                yield return new WaitForSeconds(1.5f);
            }

            float timeElapsed = 0;
            target = playerController.transform.position;
            Debug.Log(target);
            
            while(timeElapsed < lerpDuration)
            {
                parentObj.transform.position = Vector3.Lerp(transform.position, target, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                Debug.Log(timeElapsed);

                if(timeElapsed >= 2f)
                {
                    break;
                }

                yield return null;
            }

            yield return new WaitForSeconds(attackDelay);
        }
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Player")
        {
            gameManager.TakeDamage(1);
        }
    }

    public void DoDamage()
    {
        health--;

        if(health <= 0)
        {
            Destroy(gameObject);

            gameManager.Victory();
        }
    }
}
