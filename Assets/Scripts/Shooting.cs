using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float moveamount = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
      //  Debug.Log("We got hit by: " + collision.name);

        //Destroy projectile on hit
        Destroy(gameObject);           

        
    }

    // Update is called once per frame
    void Update()
    {
            transform.position += Vector3.right * moveamount * Time.deltaTime;
        
    }
}
    