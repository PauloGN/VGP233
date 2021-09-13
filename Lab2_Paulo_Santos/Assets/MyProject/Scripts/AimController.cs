using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AimController : MonoBehaviour
{

    public GameObject target;
    public GameObject rigObject;
    private bool on;
    private float zOffset = 3000.0f;


    // Start is called before the first frame update
    void Start()
    {
        on = false;
        rigObject.GetComponent<Rig>().weight = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = zOffset;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        //1 is the right mouse button
        if (Input.GetMouseButtonDown(1))
        {
            on = true;
            rigObject.GetComponent<Rig>().weight = 1.0f;
        }

        if (Input.GetMouseButtonUp(1))
        {
            on = false;
            rigObject.GetComponent<Rig>().weight = 0.0f;
        }

        //if on means the we are aiming

        if (on)
        {
            target.transform.LookAt(worldPos);
        }


    }
}
