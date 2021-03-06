using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScript : MonoBehaviour
{

    //================  Boss info ======================\\

    private const float bossMaxHealth = 100.0f;
    public static float bossHealth = bossMaxHealth;
    public static float bossHealthRepresentation;

    //=====================================================\\
    struct WeaponInfo
    { 
      //setters for UI
      public string weaponName;
      public float ammoAmount;
      public bool hasWeapon;
      public float dmg;
      
      public WeaponInfo(string name, float amount, bool hasWeap, float damage) { weaponName = name; ammoAmount = amount; hasWeapon = hasWeap; dmg = damage;}

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
    public static float weapDMG;

    //Player Health and Player Score
    public static int health;
    public static int score = 0;
    public static bool isPlayerDead = false;

    //Controls Variables
    public static int enemiesCounter = 0;
    public const int healthRestore = 20;
    public const int maxHealth = 100;
    public static bool winScore;

    // Start is called before the first frame update
    void Start()
    {
        
        //initializing Weapons
        rifle = new WeaponInfo("Rifle",100, true, 5.0f);
        machineGun = new WeaponInfo("Machine Gun",0, false, 3.0f);
        grenadeLaucher = new WeaponInfo("Grenade Laucher", 0, false,35.0f);
        flameThrower = new WeaponInfo("Flame Thrower", 0, false,35.0f);

        ResetValues();   

    }

    // Update is called once per frame
    void Update()
    {

        //Force to enter on Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu();
        }

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
            weapDMG = rifle.dmg;

        }    
        else if (weaponID == 2)
        {
            weaponName = machineGun.weaponName;
            ammoAmount = machineGun.ammoAmount;
            hasWeapon = machineGun.hasWeapon;
            weapDMG = machineGun.dmg;

        }
        else if (weaponID == 3)
        {
            weaponName = grenadeLaucher.weaponName;
            ammoAmount = grenadeLaucher.ammoAmount;
            hasWeapon = grenadeLaucher.hasWeapon;
            weapDMG = grenadeLaucher.dmg;

        }
        else if (weaponID == 4)
        {
            weaponName = flameThrower.weaponName;
            ammoAmount = flameThrower.ammoAmount;
            hasWeapon = flameThrower.hasWeapon;
            weapDMG = flameThrower.dmg;

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

   // player pick up informations
   public static void HealthPickup( )
    {

        health += healthRestore;

        if(health > maxHealth)
        {
           health = maxHealth;
        }

    }

    
   //Player health informations
   public static void TakeDamage( int dmg)
    {
        health -= dmg;

        if(health <= 0)
        {
            isPlayerDead = true;
            health = 0;
            Cursor.visible = true;
            winScore = true;
        }
    }

    //load scenes 

    public void PlayAgain()
    {
        //Reload the game
        SceneManager.LoadScene("Main_Scene");
    }

    public void MainMenu()
    {
        //Load the main menu
        SceneManager.LoadScene("MainMenu");
    }

    //Reset values every time that the game starts

    private void ResetValues()
    {
        winScore = false;
        Cursor.visible = false;
        isPlayerDead = false;
        score = 0;
        health = maxHealth;
        enemiesCounter = 0;
        weaponID = 1;//rifle
        //Boss Values
        bossHealth = bossMaxHealth;
        bossHealthRepresentation = bossHealth / bossMaxHealth;
    }

    //=========================  Boss Functions =========================\\

    public static void BossTakeDamage(float dmg)
    {
        bossHealth -= dmg;
        //normalize value to represent on UI
        bossHealthRepresentation = bossHealth / bossMaxHealth;

        if (bossHealth <= 0)
        {
            const int winPoints = 25000;
            score += winPoints;
            winScore = true;
        }
        

    }


}
