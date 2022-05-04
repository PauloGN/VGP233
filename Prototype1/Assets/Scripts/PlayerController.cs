using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    //public float speed = 20.0f;// pubic will expose the variable to the unity editor
    
    [SerializeField]//also will expose the variable to the unity editor but now the variable is classe protected
    private float speed = 5.0f;
    [SerializeField]
    private float turnSpeed = 15;
    [SerializeField]
    private float horizontalInput;
   // [SerializeField]
    private float forwardInput;

    void Start()
    {
        Debug.Log("Starting from player controller...");
    }

    // Update is called once per frame
    void Update()
    {

        //Set horizontal axis
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");


        //transform.Translate(0.0f,0.0f,1.0f); using hard code (x,y,z) values
        //transform.Translate(Vector3.forward); // using a vector3.forward is predefined as 0,0,1 same as above but this way is more readble and easy to understand

        //moves the car forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);//Multiplying by delta time will give us the time control of the rate of movement

        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);// moves kind of sliding from lef to right and right to left

        //transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

        //rotates the car based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);//Vector3, angle
        //vector3.up is the angle the it is going to rotate around in this case is Y/Up, angle is the amount to rotate in a given angle

    }


    public float GetForwardInputValue()
    {
        return forwardInput;
    }


}


//vector3.forward and vector3.Up are local directions based on the current object position