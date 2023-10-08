using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{

    GameManager gameManager;
    public float moveamount = 1f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveamount * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.TakeDamage();
    }
}
