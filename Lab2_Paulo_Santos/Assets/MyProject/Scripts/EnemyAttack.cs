using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage = 2;
    [SerializeField] private AudioClip attacking;

    private AudioSource enemyAudio;

    private void Start()
    {
        enemyAudio = GetComponentInParent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SaveScript.TakeDamage(damage);
            other.transform.gameObject.SendMessage("GetHit");
            enemyAudio.PlayOneShot(attacking);
            //Debug.Log("Enemy Attacking..");
        }
    }

}
