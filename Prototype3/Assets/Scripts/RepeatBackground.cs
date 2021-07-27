using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 startPosition;
    private float halfSpriteWidth;

    void Start()
    {
        //gets the initial position of the background
        startPosition = transform.position;
        //gets the halft size in x dimention of the backgroundsize
        halfSpriteWidth = GetComponent<BoxCollider>().size.x * 0.5f;// box collider has the size of the sprite in all axis

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < startPosition.x - halfSpriteWidth)
        {
            transform.position = startPosition;
        }

    }
}
