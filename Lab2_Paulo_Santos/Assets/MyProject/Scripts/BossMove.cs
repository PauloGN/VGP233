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

    [SerializeField] float rotationSpeed = 2.0f;
    [SerializeField] GameObject[] spwanPoints;
    [SerializeField] float disappearTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //gets the player reference
        playerRef = GameObject.FindGameObjectWithTag("Player");
        //
        amim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AlwaysFacigTarget();
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

}
