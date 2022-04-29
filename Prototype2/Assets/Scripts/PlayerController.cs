using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float playerSpeed = 20.0f;
    
    // The one that will be spawned by the player
    public GameObject projectTilePrefab;

    private float horizontalInput;
    private float xRange = 18.5f;
    private Vector3 add_Y_Height;

    // Start is called before the first frame update
    void Start()
    {
        add_Y_Height = new Vector3(0.0f,1.0f,0.0f);
       // Debug.Log("........");
    }

    // Update is called once per frame
    void Update()
    {
        //Get input from keyboard from -1(left) to +1(right) in this case
        horizontalInput = Input.GetAxis("Horizontal");
        //translates the player from left to right based on the keyboard input times direction given by the vector times deltaTime times PlayerSpeed
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed);

        //Checks the boundary on axis X (prevents character to move outof the setted range hold by the xRange variable)
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }else if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //Fire: if the key setted is pressed it will trigger an action.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //*1 Obs.
            Instantiate(projectTilePrefab, transform.position + add_Y_Height, transform.rotation);
        }

    }
}


/*
        Observations 

  1- GetKey() -> Recognizes the input while holding down the button, so it will be true while the button is pressed
 
 
 */