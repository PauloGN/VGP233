using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeInX = 18.0f;
    private float positionZ = 20;
    private float start = 1.5f;
    private float delay = 2.0f;
    
    // Start is called before the first frame update

    private void Start()
    {

        InvokeRepeating("SpawnAnimal", start, delay);

    }

    void SpawnAnimal()
    {
        // Gets a random Number from 0 to the size of the array
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        // gets a random value in X to fill the next position that an animal should spawn, fixed value in Y(height) and Z
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeInX, spawnRangeInX), 0.0f, positionZ);
        // instantiates the random anima in a randon position + plus the animal saved rotation 
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {

    }
}

/*
                           1*         2*     3*
     InvokeRepeating("SpawnAnimal", start, delay);
 
   1 - "SpawnAnimal" => this is the name of the funciotn the has been invoked
   2 - start => float variable that hold the value of the initial time to trigger the invokation
   3 - delay => float variable that holds the value of the amount of time between the repetition
 
 */