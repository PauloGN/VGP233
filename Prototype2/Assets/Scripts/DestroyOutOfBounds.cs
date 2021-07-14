using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float verticalBound = 32.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //destroy the gameObject once it is outof bounds
        if(transform.position.z > verticalBound || transform.position.z < -verticalBound)
        {
            Destroy(gameObject);
        }


    }
}
