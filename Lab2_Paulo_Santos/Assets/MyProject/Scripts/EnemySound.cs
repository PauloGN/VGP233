using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    private AudioSource enemyAudio;
    private int soundIDX = 0;
    private bool randomizer = true;
    private bool lastSound = true;
    private AIZombie aiZombieScript;
    [SerializeField] private AudioClip [] mysounds;
    [SerializeField] private AudioClip [] deathSounds;


    // Start is called before the first frame update
    void Start()
    {
        enemyAudio = GetComponent<AudioSource>();
        aiZombieScript = GetComponentInParent<AIZombie>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!SaveScript.isPlayerDead)
        {
            if (!aiZombieScript.isDead)
            {
                if (randomizer)
                {
                    soundIDX = Random.Range(0, mysounds.Length);
                    randomizer = false;

                    enemyAudio.PlayOneShot(mysounds[soundIDX]);
                    StartCoroutine(WaitNewSound());
                }
            }

            if (aiZombieScript.isDead)
            {

                if (lastSound)
                {
                    enemyAudio.Stop();
                    enemyAudio.volume = 1.0f;
                    soundIDX = Random.Range(0, deathSounds.Length);
                    enemyAudio.clip = deathSounds[soundIDX];
                    enemyAudio.Play();
                    lastSound = false;
                }

            }

        }
        else
        {
            enemyAudio.Stop();
        }   
    }

    //Time to change the sounds 
    IEnumerator WaitNewSound()
    {

        yield return new WaitForSeconds(mysounds[soundIDX].length);
        randomizer = true;

    }


    


}
