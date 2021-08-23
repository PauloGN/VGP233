using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI weaponType;
    [SerializeField] TextMeshProUGUI ammo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        weaponType.text = SaveScript.weaponName;
        ammo.text = SaveScript.ammoAmount.ToString();
    
    }
}
