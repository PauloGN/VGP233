using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float speed = 20.0f;
    private PlayerController playerControllerREF;
    private float leftBound = -9.0f;//limit to destroy objecs

    // Start is called before the first frame update
    void Start()
    {
        //Getting the reference of the other class by using a function Find from the GameObject method
        playerControllerREF = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if game is not over move
        if (!playerControllerREF.isGameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        //using function compareTag to destroy just the obstacle when its position becomes less than leftBound on X axis
        if (CompareTag("Obstacle") && transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }

    }
}
