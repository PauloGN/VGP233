using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIZombie : MonoBehaviour
{
    [SerializeField] private GameObject playerTarget;
    [SerializeField] private float rumSpeed = 2.3f;
    [SerializeField] private float attackDistance = 1.5f;

    private BoxCollider zombieCollider;
    private NavMeshAgent myNav;
    private Animator animatorRef;
    private float distanceToPlayer;
    private bool canMove;
    private float distanceOffset = 1.2f;


    // Start is called before the first frame update
    void Start()
    {
        myNav = GetComponent<NavMeshAgent>();
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        animatorRef = GetComponent<Animator>();
        zombieCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //Geting the player distance;
        distanceToPlayer = Vector3.Distance(playerTarget.transform.position, transform.position);

        if(distanceToPlayer < attackDistance)
        {
            animatorRef.SetBool("Attack",true);
            zombieCollider.enabled = true;
            canMove = false;
            myNav.enabled = false;

        }else if(distanceToPlayer > attackDistance + distanceOffset)
        {
            animatorRef.SetBool("Attack", false);
            zombieCollider.enabled = true;
            canMove = true;
            myNav.enabled = true;
        }

        if (canMove)
        {
              myNav.speed = rumSpeed;
              myNav.SetDestination(playerTarget.transform.position);
        }


    }


}
