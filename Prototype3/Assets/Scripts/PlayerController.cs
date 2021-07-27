using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    private float animSpeed = 0.6f;
    private AudioSource myAudioEffects;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    public ParticleSystem explosionParticle;
    public ParticleSystem stepsDirtParticle;
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

        //Setting values to the Animator parameters, this will change the intern states acording to the rules of transitions
        playerAnim.SetFloat("Speed_f",animSpeed);

        myAudioEffects = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //jump functionality
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //change to jump animation
            playerAnim.SetTrigger("Jump_trig");
            stepsDirtParticle.Stop();
            myAudioEffects.PlayOneShot(jumpSound,1.0f);//audio clip/volume percentage
            
            isOnGround = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        //Using compare tag functions to find a particular property of a specific gameObject

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            stepsDirtParticle.Play();
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            explosionParticle.Play();
            stepsDirtParticle.Stop();
            //Calls death animation 
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            myAudioEffects.PlayOneShot(crashSound,1.0f);

            Debug.Log("Game over....");
        }

    }
}
