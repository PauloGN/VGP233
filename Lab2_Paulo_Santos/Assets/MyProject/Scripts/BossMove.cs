using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    //Reference to my player
    private GameObject playerRef;
    //animator reference
    private Animator amim;
    private int spawnIDX;
    private bool attack = false;


    [SerializeField] float rotationSpeed = 2.0f;
    [SerializeField] GameObject[] spwanPoints;
    [SerializeField] float disappearTime = 1.0f;


    //Spawn blob to attack the player
    [SerializeField] Transform spawnBlobTransform;
    [SerializeField] GameObject radiationBlob;
    [SerializeField] float pauseBetweenAttacks = 3.0f;

    //Audios
    private AudioSource myAudio;
    [SerializeField] private AudioClip attackingSound;
    [SerializeField] private AudioClip getHitSound;
    [SerializeField] private AudioClip defeatedSound;

    // Start is called before the first frame update
    void Start()
    {
        //gets the player reference
        playerRef = GameObject.FindGameObjectWithTag("Player");
        //
        amim = GetComponent<Animator>();
        //
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AlwaysFacigTarget();
        Attack();
    }


    public void BlobSpawn()
    {
        Instantiate(radiationBlob, spawnBlobTransform.position, spawnBlobTransform.rotation);
        myAudio.clip = attackingSound;
        myAudio.pitch = 0.6f;
        myAudio.Play();
    }

    private void AlwaysFacigTarget()
    {
        Vector3 pos = (playerRef.transform.position - transform.position).normalized;
        Quaternion posRotation = Quaternion.LookRotation(new Vector3(pos.x, 0, pos.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, posRotation, Time.deltaTime * rotationSpeed);
    }
    private void GenerateSpawnIDX()
    {
        spawnIDX = Random.Range(0, spwanPoints.Length);
    }
    public void GetHit()
    {
        amim.SetTrigger("Damage");
        GenerateSpawnIDX();
        myAudio.clip = getHitSound;
        myAudio.pitch = 1.4f;
        myAudio.Play();
        StartCoroutine(TakeDamage());
    }

    private void Respawn()
    {
        gameObject.transform.position = spwanPoints[spawnIDX].transform.position;
    }


    IEnumerator TakeDamage()
    {
        yield return new WaitForSeconds(disappearTime);
        Respawn();
    }

    private void Attack()
    {
        if (!attack)
        {
            attack = true;
            StartCoroutine(AttackPlayer());
        }
    }


    IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(pauseBetweenAttacks);
        amim.SetTrigger("BossAttack");
        attack = false;
    }

}
