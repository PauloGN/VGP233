using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float verticalBound = 30.0f;

    // Update is called once per frame
    void Update()
    {
        //destroy the gameObject once it is outof bounds
        if(transform.position.z > verticalBound )
        {
            Destroy(gameObject);
        } else if (transform.position.z < -verticalBound)
        {
            Debug.Log("FOI PRO SACO.....(Game Over!)");
            Destroy(gameObject);
        }


    }
}
