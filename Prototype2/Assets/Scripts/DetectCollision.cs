using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) // triggers
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }

   // private void OnCollisionEnter(Collision collision) // not triggers ones


}
