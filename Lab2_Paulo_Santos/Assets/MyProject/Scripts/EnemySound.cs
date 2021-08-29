using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    private AudioSource enemyAudio;
    private int soundIDX = 0;
    private bool randomizer = true;
    [SerializeField] private AudioClip [] mysounds;


    // Start is called before the first frame update
    void Start()
    {
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (randomizer)
        {
            soundIDX = Random.Range(1,mysounds.Length);
            randomizer = false;

            enemyAudio.PlayOneShot(mysounds[soundIDX]);
            StartCoroutine(WaitNewSound());
        }

    }

    IEnumerator WaitNewSound()
    {

        yield return new WaitForSeconds(mysounds[soundIDX].length);
        randomizer = true;
    }
}