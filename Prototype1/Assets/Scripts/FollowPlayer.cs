using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    #region Variables

    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offSet = new Vector3(0.0f, 1.0f, -3.25f);


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 newPos = player.transform.position + offSet;
            transform.position = newPos;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
    }
}
