using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private GameObject focalPointREF;
   [SerializeField] private bool hasPowerUp = false;
    private float powerupStreth = 25.0f;
    private Vector3 indicatorOffset = new Vector3 (0.0f,-0.3f,0.0f);

    public float speed = 10.0f;
    public GameObject indicator;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPointREF = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        indicator.transform.position = transform.position + indicatorOffset;
    }

    private void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPointREF.transform.forward * speed * verticalInput, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUptg"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            //starting a coroutine 
            indicator.SetActive(true);
            StartCoroutine(PoweruoCountDown());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemytg") && hasPowerUp)
        {
            Debug.Log("Buuum!");
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();

            //Getting the direction to apply the impuse and push the enemy away
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRB.AddForce(awayFromPlayer * powerupStreth, ForceMode.Impulse);

        }
    }


    IEnumerator PoweruoCountDown()
    {
        yield return new WaitForSeconds(5);//starts a counter internally in this case 5 seconds after the time it will execute the next line of code
        hasPowerUp = false;
        indicator.SetActive(false);
    }


    public float playerSpeed()
    {
        return speed;
    }

}
