using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI weaponType;
    [SerializeField] TextMeshProUGUI ammo;
    [SerializeField] TextMeshProUGUI ammoLabel;
    [SerializeField] TextMeshProUGUI playerHealth;

    //Labels to type of ammunition
    private string ammoWeapon = "AMMO:";
    private string fuelWeapon = "FUEL:";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        weaponType.text = SaveScript.weaponName;

        playerHealth.text = SaveScript.health.ToString();
        //defines the lable of the ammo
        if(SaveScript.weaponID == 4)
        {
            ammoLabel.text = fuelWeapon;
            ammo.text = (Mathf.Round(SaveScript.ammoAmount).ToString());
        }
        else
        {
            ammoLabel.text = ammoWeapon;
            ammo.text = SaveScript.ammoAmount.ToString();
        }

    }
}
