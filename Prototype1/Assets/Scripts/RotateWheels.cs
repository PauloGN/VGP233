using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheels : MonoBehaviour
{

    PlayerController playerControllerREF = null;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerREF = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerControllerREF != null)
        {
        }

          float speed = playerControllerREF.GetForwardInputValue();
          transform.Rotate(Vector3.right, Time.deltaTime * speed * 400.0f);
        
    }
}
