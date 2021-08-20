using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeAssets : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
   
    public void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject, 0.1f);
    }


}
