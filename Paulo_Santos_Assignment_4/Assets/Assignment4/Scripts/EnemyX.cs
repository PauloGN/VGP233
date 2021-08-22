using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private static float speedRate = 1.0f;//Controls the amount of speed to be increased
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerGoal = GameObject.Find("Player Goal");
        player = GameObject.Find("Player");
        //enemy speed is 30% of the player speed
        speed = player.GetComponent<PlayerControllerX>().GetPlayerSpeed() * 0.3f * speedRate;
        enemyRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime, ForceMode.Acceleration);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

    //Takes care of the speed rate increase in each instantiated object;
    public static void UpdateSpeed(float currentSpeed)
    {
        //currentSpeed coming from SpawnManagerX script // private float speedRate = 0.1f; // Speed rate to increase
        speedRate += currentSpeed;
    }

}
