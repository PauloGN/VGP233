using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Animator amim;
    private AnimatorStateInfo playerInfo;
    private AnimatorStateInfo playerInfoLayer2;
    // Rotation speed while moving
    private float rotateSpeed;
    [SerializeField] private GameObject crossHairRef;
    [SerializeField] private float stillRotationSpeed = 40.0f;
    [SerializeField] private float walkRotationSpeed = 100.0f;
    [SerializeField] private float runningRotationSpeed = 150.0f;
    [SerializeField] private float aimRotationSpeed = 180.0f;
    [SerializeField] private GameObject bloodFX;
   


    // Start is called before the first frame update
    void Start()
    {
        //access the conditions 
        amim = GetComponent<Animator>();
        //desable cross hair view
        crossHairRef.SetActive(false);
        bloodFX.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!SaveScript.isPlayerDead)
        {
            //checks the information inside animator state base
            //Allows to enter the player base animator and check the tags labeled in each state created inside the base animator using its index
            playerInfo = amim.GetCurrentAnimatorStateInfo(0);
            playerInfoLayer2 = amim.GetCurrentAnimatorStateInfo(1);

            float moveDirection = Input.GetAxis("Vertical");
            float rotateDirection = Input.GetAxis("Mouse X");

            //Layer 2 active and reset
            if (playerInfoLayer2.IsTag("Hit"))
            {
                amim.SetLayerWeight(1, 1);
                bloodFX.SetActive(true);


            }
            else if (playerInfoLayer2.IsTag("Idle"))
            {
                amim.SetLayerWeight(1, 0);
                bloodFX.SetActive(false);
            }


            if (playerInfo.IsTag("Still"))//set the speed rotation if character is stoped
            {
                rotateSpeed = stillRotationSpeed;
            }

            if (playerInfo.IsTag("Walk"))//set the speed rotation if character is walking
            {
                rotateSpeed = walkRotationSpeed;
            }

            if (playerInfo.IsTag("Running"))//set the speed rotation if character is walking
            {
                rotateSpeed = runningRotationSpeed;
            }

            if (playerInfo.IsTag("Aim"))//set the speed rotation if character is aiming
            {
                rotateSpeed = aimRotationSpeed;
            }

            // translations movements
            if (moveDirection > 0)
            {
                //forward
                if (Input.GetKey(KeyCode.LeftShift))//run
                {
                    amim.SetBool("Running", true);
                }
                else
                {
                    amim.SetBool("Running", false);
                    amim.SetBool("Walk", true);
                }
            }

            if (moveDirection == 0)//stop moving
            {
                amim.SetBool("Walk", false);
                amim.SetBool("WalkBack", false);
                amim.SetBool("Running", false);
            }

            if (moveDirection < 0)
            {
                amim.SetBool("WalkBack", true);
            }

            //Rotation Movements
            //follow mouse movement X to rotate right and left
            if (rotateDirection > 0)
            {
                transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            }

            if (rotateDirection < 0)
            {
                transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
            }

            //Mouse inputs

            if (Input.GetMouseButtonDown(1))
            {
                amim.SetBool("Aim", true);
                //crossHairRef.transform.position = new Vector3(0,0,0);
                crossHairRef.SetActive(true);
            }
            if (Input.GetMouseButtonUp(1))
            {
                amim.SetBool("Aim", false);
                crossHairRef.SetActive(false);
            }
        }//end of player is dead condition
    }

    public void GetHit()
    {

        //amim.SetLayerWeight(1, 1);
        amim.SetTrigger("React");

    }


}
