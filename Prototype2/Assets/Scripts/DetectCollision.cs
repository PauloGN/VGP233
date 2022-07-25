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

/*
Collision detection vs Collision Resolution

**** Collision detection

it is the response of true when two objects collide each other
checking true "IS TRIGGER" inside the collision component

**** Collision Resolution

in this case the engine will try to resolve mathematicaly the collision between two game objects
taking in consideration their mass, velocity and direction


*/