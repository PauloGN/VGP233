using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3.0f;

      
    private int bossDMG = 10;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            SaveScript.TakeDamage(bossDMG);
        }

    }


}
