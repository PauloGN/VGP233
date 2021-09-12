using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMove : MonoBehaviour
{
    [SerializeField] AudioClip acidSound;
    [SerializeField] float moveSpeed = 3.0f;
    [SerializeField] private int bossDMG = 10;
    private Transform playerPos;
    private AudioSource myAudio;
    private MeshRenderer myMesh;
    private Vector3 offSetY;
    private bool canHitSomething = true;
  
    private void Start()
    {
        //Const values to define offset in heigh of the blob
        const float nullval = 0.0f;
        const float height = 1.4f;
        //getting audion component
        myAudio = GetComponent<AudioSource>();

        //getting player reference transform
        offSetY = new Vector3(nullval, height, nullval);
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        //geting self render ref
        myMesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame 

    void Update()
    {
        if (!SaveScript.isPlayerDead)
        {
            // Set enemy blob towards player and move there
            Vector3 lookDirection = ((playerPos.position + offSetY) - transform.position).normalized;
            transform.position += lookDirection * Time.deltaTime * moveSpeed;
        }

    }



    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Stone"))
        {
            if (canHitSomething)
            {
                canHitSomething = false;
                StartCoroutine(HitWall());
            }

        }


        if (other.CompareTag("Player"))
        {
            if (canHitSomething)
            {
                canHitSomething = false;
                other.transform.gameObject.SendMessage("GetHit");
                StartCoroutine(CauseDamage());
            }
        }
              
    }


    //Hit Player
    private IEnumerator CauseDamage()
    {
        myAudio.PlayOneShot(acidSound);
        SaveScript.TakeDamage(bossDMG);
        myMesh.enabled = false;
        yield return new WaitForSeconds(acidSound.length);
        canHitSomething = true;
        Destroy(gameObject);
    }

    //Hit wall

    private IEnumerator HitWall()
    {
        myAudio.PlayOneShot(acidSound);
        myMesh.enabled = false;
        yield return new WaitForSeconds(acidSound.length);
        canHitSomething = true;
        Destroy(gameObject);
    }

}
