using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private Animator cameraAmin;


    // Start is called before the first frame update
    void Start()
    {
        cameraAmin = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            cameraAmin.SetBool("Aim_cam",true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            cameraAmin.SetBool("Aim_cam", false);
        }

    }
}
