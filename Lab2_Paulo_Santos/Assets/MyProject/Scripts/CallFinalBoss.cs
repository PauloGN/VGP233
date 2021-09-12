using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallFinalBoss : MonoBehaviour
{

    [SerializeField] GameObject finalBoss;
    [SerializeField] GameObject bossHealthBar;
    [SerializeField] GameObject closePath;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            finalBoss.SetActive(true);
            bossHealthBar.SetActive(true);
            closePath.SetActive(true);
        }

    }

    private void Update()
    {
        if (SaveScript.isPlayerDead)
        {
            bossHealthBar.SetActive(false);
        }
    }





}
