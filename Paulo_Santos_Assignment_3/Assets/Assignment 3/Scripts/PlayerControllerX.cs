﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = false;

    public float floatForce = 1.0f;
    private float gravityModifier = 1.5f;
    private float topLimit = 14.5f;
    private float bottomLimit = 1.0f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceOffSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        //if a rigidBody component is found inside the player controller it will be asigned in the variable
        playerRb = GetComponent<Rigidbody>();
        // Apply a small upward force at the start of the game      
        playerRb.AddForce(Vector3.up * floatForce,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        CheckOutOfBound();
        if (Input.GetKey(KeyCode.Space) && !gameOver && transform.position.y < topLimit)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);     
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

    private void CheckOutOfBound()
    {
        if(transform.position.y > topLimit)
        {
            transform.position = new Vector3(transform.position.x, topLimit, transform.position.z);
        }

        if (transform.position.y < bottomLimit && !gameOver)
        {
            float multiplier = 1.5f;
            playerRb.AddForce(Vector3.up * floatForce * multiplier, ForceMode.Impulse);
            playerAudio.PlayOneShot(bounceOffSound, 1.0f);
        }

    }


}
