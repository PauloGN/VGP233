using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIZombie : MonoBehaviour
{
    enum EnemyType { movement01, movement02 };
    [SerializeField] private GameObject playerTarget;
    [SerializeField] private float rumSpeed = 2.3f;
    [SerializeField] private float walk_CrawlSpeed = 0.5f;
    [SerializeField] private float attackDistance = 1.5f;
    [SerializeField] private float delayToDestroy = 2.1f;
    [SerializeField] private int points2KillThis = 100;

    private BoxCollider zombieCollider;
    private NavMeshAgent myNav;
    private NavMeshObstacle myNavObstacle;
    private Animator animatorRef;
    private float distanceToPlayer;
    private bool canMove;
    private float distanceOffset = 1.1f;
    private float BarrelDMG = 50f;

    [SerializeField] private EnemyType enemyType;
    [SerializeField] private float health;
    [SerializeField] private float rotationSpeed = 2.0f;

    //Death conditions
    public bool isDead;
  

    // Start is called before the first frame update
    void Start()
    {
        myNav = GetComponent<NavMeshAgent>();
        myNavObstacle = GetComponent<NavMeshObstacle>();
        myNavObstacle.enabled = false;
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        animatorRef = GetComponent<Animator>();
        zombieCollider = GetComponent<BoxCollider>();
        EnemyMovementType();

    }

    // Update is called once per frame
    void Update()
    {

        if (!isDead)
        {
            //Geting the player distance;
            distanceToPlayer = Vector3.Distance(playerTarget.transform.position, transform.position);

            if (distanceToPlayer < attackDistance)
            {
                animatorRef.SetBool("Attack", true);
                zombieCollider.enabled = true;
                canMove = false;
                
                // myNav.enabled = false;
                // myNavObstacle.enabled = true;
                myNav.isStopped = true;

                //fix Enemy rotation to face to the player
                Vector3 pos = (playerTarget.transform.position - transform.position).normalized;
                Quaternion posRotation = Quaternion.LookRotation(new Vector3(pos.x,0,pos.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, posRotation, Time.deltaTime * rotationSpeed);

            }
            else if (distanceToPlayer > attackDistance + distanceOffset)
            {
                animatorRef.SetBool("Attack", false);
                zombieCollider.enabled = true;
                canMove = true;
               
                //myNavObstacle.enabled = false;
                // myNav.enabled = true;
                myNav.isStopped = false;

            }

            if (canMove)
            {
                myNav.SetDestination(playerTarget.transform.position);
            }

        }
    }


    private void EnemyMovementType()
    {

        if(enemyType == EnemyType.movement01)
        {
            myNav.speed = rumSpeed;
            animatorRef.SetLayerWeight(0,1);
        }
        else
        {
            animatorRef.SetLayerWeight(1, 1);
            myNav.speed = walk_CrawlSpeed;
        }

    }


    public void TakeDamage()
    {

        health -= SaveScript.weapDMG;

        if(health <= 0)
        {
            // Gain points to kill enemies
            SaveScript.score += points2KillThis;
            isDead = true;
            //Calls the death animation
            animatorRef.SetTrigger("Death");

            canMove = false;
            myNav.enabled = false;
            zombieCollider.enabled = false;

            //Enemy counter decrease
            SaveScript.enemiesCounter--;

            StartCoroutine(TimeToDestroyOBJ());      

        }  

    }


    public void TakeDamageFromBarrel()
    {

        health -= BarrelDMG;

        if (health <= 0)
        {
            SaveScript.score += points2KillThis;
            isDead = true;
            animatorRef.SetTrigger("Death");
            canMove = false;
            myNav.enabled = false;
            zombieCollider.enabled = false;

            //Enemy counter decrease
            SaveScript.enemiesCounter--;

            StartCoroutine(TimeToDestroyOBJ());           

        }

    }


    private IEnumerator TimeToDestroyOBJ()
    {
        yield return new WaitForSeconds(delayToDestroy);
        Destroy(gameObject);
    }

}
