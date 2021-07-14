using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //Initializes the offset position 
        offset = new Vector3(37.0f,0.0f,3.0f);

    }

    // Update is called once per frame
    void Update()
    {
        //Sets the camera position and update it frame by frame according to the plane movement
        transform.position = plane.transform.position + offset;
    }
}
