using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AcivateSpawn : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            spawnPoint.SetActive(true);
            Destroy(gameObject);

        }

    }


}
