using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    //This time can be defined on the Unity interface by default as 0 the same as the minimum ball spawning interval
    public float dogInterval = 3.0f;

    private float timeControl = 0.0f;

    // Update is called once per frame
    void Update()
    {
        //avoid spam by using time control
        timeControl += Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(timeControl >= dogInterval)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timeControl = 0.0f;
            }
        }
    }
}
