using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    //force
    private float minSpeed = 13.0f;
    private float maxSpeed = 18.0f;
    //rotatin torque
    private float maxTorque = 8.0f;
    //position
    private float xRange = 4.2f;
    private float ySpawnPoint = 6.0f;
    //Game Manager REF
    private GameManager gameManagerRef;

    public int pointVal;
    public ParticleSystem explosionParticles;

    // Start is called before the first frame update
    void Start()
    {
        //getting the rigdbody component
        targetRB = GetComponent<Rigidbody>();

        //apply a force to the target object goes up
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        //apply a rotation force
        targetRB.AddTorque(RandomTorque(), ForceMode.Impulse);
        //set a ramdom X position and fixed y height to spwan the target object
        targetRB.transform.position = RandomSpawnPosition();
        //getting the reference to a game manager script component inside the GameManager Object;
        gameManagerRef = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

  //Generationg randons vector 3 to feed random values 
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private Vector3 RandomTorque()
    {
        return new Vector3( Random.Range(maxTorque, -maxTorque),Random.Range(maxTorque, -maxTorque),Random.Range(maxTorque, -maxTorque));
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPoint);
    }

    //destroy objects on trigger depending with an excepetion of bad and good tags
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Bad") && !other.CompareTag("Good"))
        {

            if (CompareTag("Good"))
            {
                gameManagerRef.GameOver();
            }
            
            Destroy(gameObject);
            
        }
    }

    // destroy objects after ponting the mouse cursor and clicking on it
    private void OnMouseDown()
    {
        if (gameManagerRef.isGameActive)
        {
            gameManagerRef.UpdateScore(pointVal);
            Instantiate(explosionParticles, transform.position, explosionParticles.transform.rotation);
            Destroy(gameObject);
        }
    }

}
