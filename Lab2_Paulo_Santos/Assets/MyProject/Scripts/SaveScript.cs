using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{

    struct WeaponInfo
    { 
      //setters for UI
      public string weaponName;
      public float ammoAmount;
      public bool hasWeapon;
      
      public WeaponInfo(string name, float amount, bool hasWeap) { weaponName = name; ammoAmount = amount; hasWeapon = hasWeap;}

    }

    // 1 = Rifle / 2 = RapidWeap / 3 = Grenade / 4 = Flame thrower
    public static int weaponID = 1;
    //List of Weapons
    static WeaponInfo rifle;
    static WeaponInfo machineGun;
    static WeaponInfo grenadeLaucher;
    static WeaponInfo flameThrower;
    //Update info variables
    public static string weaponName;
    public static float ammoAmount;
    public static bool hasWeapon;
    public static int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        //initializing Weapons
        rifle = new WeaponInfo("Rifle",100, true);
        machineGun = new WeaponInfo("Machine Gun",0, false);
        grenadeLaucher = new WeaponInfo("Grenade Laucher", 0, false);
        flameThrower = new WeaponInfo("Flame Thrower", 0, false);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateWeaponInfo();
        //Test switch Weapons
        if (Input.GetKeyDown(KeyCode.Alpha1) && rifle.hasWeapon)
        {
            weaponID = 1;
            
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2) && machineGun.hasWeapon)
        {
            weaponID = 2;
           
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && grenadeLaucher.hasWeapon)
        {
            weaponID = 3;
           
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && flameThrower.hasWeapon)
        {
            weaponID = 4;
            
        }
    }

    //Updating data acording to the weapon equiped (UI INFO)
    public void UpdateWeaponInfo()
    {
        
        if (weaponID == 1)
        {
            weaponName = rifle.weaponName;
            ammoAmount = rifle.ammoAmount;
            hasWeapon = rifle.hasWeapon;

        }    
        else if (weaponID == 2)
        {
            weaponName = machineGun.weaponName;
            ammoAmount = machineGun.ammoAmount;
            hasWeapon = machineGun.hasWeapon;

        }
        else if (weaponID == 3)
        {
            weaponName = grenadeLaucher.weaponName;
            ammoAmount = grenadeLaucher.ammoAmount;
            hasWeapon = grenadeLaucher.hasWeapon;

        }
        else if (weaponID == 4)
        {
            weaponName = flameThrower.weaponName;
            ammoAmount = flameThrower.ammoAmount;
            hasWeapon = flameThrower.hasWeapon;

        }

    }
    //Updating data acording to the pickup picked Up
    public static void UpdateWeaponPickupInfo(int id, float ammo)
    {
        
        switch (id)
        {
            case 1:
                rifle.ammoAmount += ammo;
                if (rifle.ammoAmount > 0)
                {
                    rifle.hasWeapon = true;
                }
                break;
            case 2:
                machineGun.ammoAmount += ammo;
                if (machineGun.ammoAmount > 0)
                {
                    machineGun.hasWeapon = true;
                }
                break;
            case 3:
                grenadeLaucher.ammoAmount += ammo;
                if (grenadeLaucher.ammoAmount > 0)
                {
                    grenadeLaucher.hasWeapon = true;
                }
                break;
            case 4:
                flameThrower.ammoAmount += ammo;
                if (flameThrower.ammoAmount > 0)
                {
                    flameThrower.hasWeapon = true;
                }
                break;
        }


    }
    //Updating Weapon ammo
    public static void UpdateAmmo(int id, int decrease)
    {
        switch (id)
        {
            case 1:
                rifle.ammoAmount -= decrease;
                if (rifle.ammoAmount <= 0)
                {
                    rifle.ammoAmount = 0;
                    rifle.hasWeapon = false;
                }
                break;
            case 2:
                machineGun.ammoAmount -= decrease;
                if (machineGun.ammoAmount <= 0)
                {
                    machineGun.ammoAmount = 0;
                    machineGun.hasWeapon = false;
                }
                break;
            case 3:
                grenadeLaucher.ammoAmount -= decrease;
                if (grenadeLaucher.ammoAmount <= 0)
                {
                    grenadeLaucher.ammoAmount = 0;
                    grenadeLaucher.hasWeapon = false;
                }
                break;
            case 4:
                flameThrower.ammoAmount -= (float)decrease * Time.deltaTime * 2;
                if (flameThrower.ammoAmount <= 0)
                {
                    flameThrower.ammoAmount = 0.0f;
                    flameThrower.hasWeapon = false;
                }
                break;

        }
    }

   public static void TakeDamage( int dmg)
    {
        health -= dmg;

        if(health <= 0)
        {
            health = 0;
        }
    }

}
