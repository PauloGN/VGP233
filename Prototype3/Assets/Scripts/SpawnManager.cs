using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawnPosition = new Vector3(33.0f, 0.0f,0.0f);
    private float startOnTime = 1.5f;
    private float repeatRate = 2.0f;
    private PlayerController playerControllerREF;


    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerREF = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle",startOnTime,repeatRate);
    }

 

    private void SpawnObstacle()
    {
        if (!playerControllerREF.isGameOver)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }

    }

}
