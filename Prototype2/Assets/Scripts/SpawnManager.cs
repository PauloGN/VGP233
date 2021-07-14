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
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeInX, spawnRangeInX), 0.0f, positionZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
