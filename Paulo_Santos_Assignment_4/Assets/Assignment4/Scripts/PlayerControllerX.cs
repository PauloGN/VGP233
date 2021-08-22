using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed ;//Current speed
    private float normalSpeed = 500.0f;
    private float turboSpeed = 900.0f; 
    private GameObject focalPoint;
   [SerializeField] private GameObject turboEffect;

    public bool hasPowerup;
    public bool hasTurbo;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private float normalStrength = 10.0f; // how hard to hit enemy without powerup
    private float powerupStrength = 25.0f; // how hard to hit enemy with powerup
    public float turboTime = 7.0f; //duration of turbo boost

    void Start()
    {
        speed = normalSpeed;
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }


    private void Update()
    {
        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
        turboEffect.transform.position = transform.position;

        //The players can use it whenever they want, but this condition controls the call flow
        if (Input.GetKeyDown(KeyCode.Space) && !hasTurbo)
        {
            hasTurbo = true;
            speed = turboSpeed;
            turboEffect.GetComponent<ParticleSystem>().Play();
            StartCoroutine(TurboBoost());
        }
    }

    void FixedUpdate()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime); 

    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =  other.gameObject.transform.position - transform.position; 
           
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);

            }


        }
    }

    //returns the player speed
    public float GetPlayerSpeed()
    {
        return speed;
    }
    // Coroutine to control the turbo duration
    IEnumerator TurboBoost()
    {
        yield return new WaitForSeconds(turboTime);
        hasTurbo = false;
        speed = normalSpeed;
    }

}
