﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 15.0f;
    private float rotationSpeed = 100.0f;
    private float verticalInput = 0.0f;
    Quaternion lastRotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        // Checks input values to prevent the plane from automatically tilting
        if (verticalInput != 0)
        {
           transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime * verticalInput);
           lastRotation = transform.rotation;
        }
        else
        {
            transform.rotation = lastRotation;
        }
       
    }
}
