using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;

    //range for spawner [-XRange ... XRange]
    public float XRange = 40.0f;

    private void SpawnRandomOne()
    {
        //get random integer
        int rnd = Random.Range(0, EnemyPrefabs.Length);

        //get random x-coord
        float x_rnd = Random.Range(-XRange, XRange);

        //instantiate the object
        Instantiate(EnemyPrefabs[rnd], new Vector3(Random.Range(462, 602), 90, 0), EnemyPrefabs[rnd].transform.rotation);
    }

    private void Start()
    {
        //for (int i = 0;i<20;i++)

        InvokeRepeating("SpawnRandomOne", 1.0f, 1.0f);

        SpawnRandomOne();
    }
}
