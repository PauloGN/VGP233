using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{

    public GameObject enemy;

    private float spawnRangeInX = 18.0f;
    private float positionZ = 20;
    private float start = 1.5f;
    private float delay = 2.0f;


    void SpawnAnimal()
    {
       // int animalIndex = Random.Range(0, enemy.Length);

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeInX, spawnRangeInX), 0.0f, positionZ);

        Instantiate(enemy, spawnPos, enemy.transform.rotation);

    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimal", start, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
