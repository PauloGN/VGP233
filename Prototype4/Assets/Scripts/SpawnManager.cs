using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerupPrefab;
    private float spawnRange = 6.0f;
    private float heithSpawnRange = 2.0f;
    private int enemyCount = 0;
    public int EnemiesToSpawm = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(EnemiesToSpawm);
        Instantiate(powerupPrefab, generateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyAI>().Length;

        if(enemyCount <= 0)
        {
            EnemiesToSpawm++;
            SpawnEnemyWave(EnemiesToSpawm);
            Instantiate(powerupPrefab, generateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }


    private void SpawnEnemyWave(int enemiesToSpwam)
    {
        for (int i = 0; i < enemiesToSpwam; i++)
        {
            Instantiate(enemyPrefab, generateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }



    //generates a random spamw positions 
    Vector3 generateSpawnPosition()
    {

        float xSpawnRange = Random.Range(-spawnRange, spawnRange);
        float zSpawnRange = Random.Range(-spawnRange, spawnRange);
        
        return new Vector3(xSpawnRange, heithSpawnRange, zSpawnRange);
    }

}
