using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Animator amim;
    [SerializeField] private float rotationSpeed = 2.0f;

    //Start is called before the first frame update
    void Start()
    {

        amim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirection = Input.GetAxis("Vertical");
        float rotateDirection = Input.GetAxis("Mouse X");

        // translations movements
        if (moveDirection > 0)
        {
            amim.SetBool("Walk", true);
        }

        if(moveDirection == 0)
        {
            amim.SetBool("Walk", false);
            amim.SetBool("WalkBack", false);
        }

        if (moveDirection < 0)
        {
            amim.SetBool("WalkBack", true);
        }

        //Rotation Movements

        if (rotateDirection > 0)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        if (rotateDirection < 0)
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }

    }
}
