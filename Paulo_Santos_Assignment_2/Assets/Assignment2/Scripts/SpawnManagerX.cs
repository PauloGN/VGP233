﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22.0f;
    private float spawnLimitXRight = 7.0f;
    private float spawnPosY = 30.0f;

    private float startDelay = 1.0f;
    private float spawnInterval = Random.Range(3.0f, 5.0f);
    private float timeControl = 0.0f;

    // Start is called before the first frame update
    void Start()
    { 
       // InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }


    private void Update()
    {
        timeControl += Time.deltaTime;

        if(timeControl >= spawnInterval)
        {
            SpawnRandomBall();
            timeControl = 0.0f;
            spawnInterval = Random.Range(3.0f, 5.0f);
        }

    }


    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int ramdonBall = Random.Range(0,ballPrefabs.Length);
        
        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ramdonBall], spawnPos, ballPrefabs[ramdonBall].transform.rotation);
    }

}