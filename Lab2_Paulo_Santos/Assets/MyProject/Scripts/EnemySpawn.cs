using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] slowEnemies;
    [SerializeField] private GameObject[] fastEnemies;
    [SerializeField] private Transform spawnPlace;
    [SerializeField] GameObject burnOutFX;
    [SerializeField] GameObject sparks;
    [SerializeField] ParticleSystem explosion;

    private bool canSpawn = true;
    private int spawnPointResistance = 30;
    private int barrelDmg = 10;
    private int flameDmg = 5;

    //Delay Control
    private float spawnDelay = 0.3f;
    private float spawnDelayMin = 3.2f;
    private float spawnDelayMax = 7.5f;
    private float damageDelayTime = 0.0f;
    private const float resetDmgDelay = 0.5f;

    //Wave Control
    private int enemiesWave = 40;
    private int spawnedPerCycle = 2;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn && SaveScript.enemiesCounter < enemiesWave)
        {
            canSpawn = false;
            StartCoroutine(Spawning());
        }
    }

    //Coroutinte to spaw random enemies
    IEnumerator Spawning()
    {
        //random Time to spawn
        spawnDelay = Random.Range(spawnDelayMin, spawnDelayMax);

        //Ramdom Index to get and enemy
        int slowIDX = Random.Range(0, slowEnemies.Length);
        int fastIDX = Random.Range(0, fastEnemies.Length);

        //wait and Spawn
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(slowEnemies[slowIDX], spawnPlace.position, spawnPlace.rotation);
        
        //random Time to spawn
        spawnDelay = Random.Range(spawnDelayMin, spawnDelayMax);
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(fastEnemies[fastIDX], spawnPlace.position, spawnPlace.rotation);

        canSpawn = true;
        SaveScript.enemiesCounter += spawnedPerCycle;

    }

    //Damage and destroy Spawn point
    private void OnParticleCollision(GameObject other)
    {

        damageDelayTime -= Time.deltaTime;

        if (damageDelayTime <= 0.0f)
        {

            //Checks if the damage is causede by a barrel explosion or Flame thrower
            if (other.CompareTag("B_Explosion"))
            {
                Debug.Log("O barril explodiu...");
                spawnPointResistance -= barrelDmg;
            }
            else
            {
               
               Debug.Log("Is burning......");
               spawnPointResistance -= flameDmg;

            }

            burnOutFX.SetActive(true);
            damageDelayTime = resetDmgDelay;
        }

        if(spawnPointResistance <= 15)
        {
            sparks.SetActive(true);
            if (spawnPointResistance <= 0)
            {

                Instantiate(explosion, spawnPlace.position, spawnPlace.rotation);
                Destroy(gameObject);

            }
        }


    }


}
