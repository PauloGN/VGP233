using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{

    public static int WeaponID = 4;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Test switch Weapons
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponID = 1;
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponID = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeaponID = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            WeaponID = 4;
        }
    }
}
