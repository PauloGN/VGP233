using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AcivateSpawn : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] private AudioClip[] bossAudio;

    private AudioSource myAudio;

    private float destroyDelay = 8.0f;
    private bool isPlayingAudio;

    private void Start()
    {
        isPlayingAudio = false;
        myAudio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (!isPlayingAudio)
            {
                isPlayingAudio = true;
                int idx = Random.Range(0, bossAudio.Length);

                spawnPoint.SetActive(true);
                myAudio.PlayOneShot(bossAudio[idx]);
                Destroy(gameObject, destroyDelay);
            }

        }

    }


}
