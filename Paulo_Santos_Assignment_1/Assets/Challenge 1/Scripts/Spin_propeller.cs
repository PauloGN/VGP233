using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin_propeller : MonoBehaviour
{
    //propeller speed
    private float speed = 500.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates the propeller around the z-axis based on the given speed
        transform.Rotate(Vector3.forward, Time.deltaTime * speed);
    }
}
