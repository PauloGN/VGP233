using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour

{
    private GameObject playerREF;
    private Rigidbody enemyRB;
    private float speed;
    private float speedRate = 1.03f;

    private float boundY = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerREF = GameObject.Find("Player");
        enemyRB = GetComponent<Rigidbody>();
        //enemy Initial speed is 80% of the player speed
        speed = playerREF.GetComponent<PlayerController>().playerSpeed() * 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -boundY)
        {
            Destroy(gameObject);
        }
    }

  
    private void FixedUpdate()
    {
        //*Notes - 1
        Vector3 lookDirection = (playerREF.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * speed, ForceMode.Acceleration);   

    }

    /*  Notes - 1
   *  
   *  to get the direction that the enemy must follow we have to subtract the player's (destination) position
   *  by the enemy's (origin) position and to exclude the magnitude we just normalize this difference 
   */

}
