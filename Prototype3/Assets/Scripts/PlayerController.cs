using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    private float animSpeed = 0.6f;


    public float jumpForce = 1000.0f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //if a rigidBody component is found inside the player controller it will be asigned in the variable
        playerRB = GetComponent<Rigidbody>();

        //access the physics of the engine and modify it.
        Physics.gravity *= gravityModifier;

        //Gets the animator propreties from the hierarc gameobject
        playerAnim = GetComponent<Animator>();

        //Setting values to the Animator parameters, this will change the intern states acordin to the rules of transitions
        playerAnim.SetFloat("Speed_f",animSpeed);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        //Using compare tag functions to find a particular property of a specific gameObject

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);

            Debug.Log("Game over....");
        }

    }
}
