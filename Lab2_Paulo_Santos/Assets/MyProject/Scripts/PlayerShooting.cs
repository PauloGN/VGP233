using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //Weapons
    [SerializeField] private Transform muzzleSpawn;
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private GameObject stoneImpact;
    [SerializeField] private GameObject metalImpact;
    [SerializeField] private GameObject bloodImpact;
    //Sounds
    private AudioSource playerSounds;
    [SerializeField]private AudioClip singleShoot;
    [SerializeField]private AudioClip rapidShoot;
    [SerializeField]private AudioClip grenadeSound;
    [SerializeField]private AudioClip flameSound;
    [SerializeField]private AudioClip pickUpSound;
    [SerializeField]private AudioClip gameOverSound;
    //variables of control
    private bool rapidPlay = true;
    private bool shooting = true;
    private bool isGameOver;
    [SerializeField]private float rapidDelay = 0.2f;
    //Grenades
    [SerializeField] private GameObject grenadeSmoke;
    [SerializeField] private GameObject grenadeExplosion;
    //FireWeapon
    [SerializeField] private GameObject flameStream;

    //References
    [SerializeField] private LayerMask playerLayerMask;
    private AIZombie aiZombieScript;//**************************

    //standar values
    private const int ammoDecrease = 1;
    private bool fireFuel = false;

    //physics
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        playerSounds = GetComponent<AudioSource>();
        isGameOver = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (!SaveScript.isPlayerDead)
        {
            bool isShooting = false;
            //Regurlar Weeapon behavior
            if (SaveScript.weaponID == 1)
            {
                isShooting = (Input.GetMouseButton(1) && Input.GetMouseButtonDown(0)) && SaveScript.hasWeapon;
                if (isShooting)
                {
                    Instantiate(muzzleFlash, muzzleSpawn.position, muzzleSpawn.rotation);
                    playerSounds.PlayOneShot(singleShoot);
                    //Decrease Rifle ammo
                    SaveScript.UpdateAmmo(1, ammoDecrease);

                    Hits();
                }
            }
            // Machine Gun behavior
            if (SaveScript.weaponID == 2)
            {
                isShooting = (Input.GetMouseButton(1) && Input.GetMouseButton(0)) && SaveScript.hasWeapon;
                if (isShooting)
                {
                    Instantiate(muzzleFlash, muzzleSpawn.position, muzzleSpawn.rotation);


                    if (rapidPlay)
                    {
                        rapidPlay = false;
                        playerSounds.loop = true;
                        playerSounds.clip = rapidShoot;
                        playerSounds.pitch = 3;
                        playerSounds.Play();

                    }

                    if (shooting)
                    {
                        //decrease ammo inside coroutine
                        shooting = false;
                        StartCoroutine(RapidFire());
                    }


                }

                //Conditions to Stop shooting with Machine Gun
                if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0) || !SaveScript.hasWeapon)
                {
                    rapidPlay = true;
                    playerSounds.loop = false;
                    playerSounds.pitch = 1;
                    playerSounds.Stop();
                }

            }
            //Grenade behavior
            if (SaveScript.weaponID == 3)
            {
                isShooting = (Input.GetMouseButton(1) && Input.GetMouseButtonDown(0) && SaveScript.hasWeapon);
                if (isShooting)
                {
                    //grenade effect when shooting
                    Instantiate(grenadeSmoke, muzzleSpawn.position, muzzleSpawn.rotation);

                    //Decrease grenade ammo
                    SaveScript.UpdateAmmo(3, ammoDecrease);

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit, 1000, ~playerLayerMask))
                    {
                        StartCoroutine(Grenade());
                    }

                }
            }

            //FireStream Weap
            if (SaveScript.weaponID == 4)
            {
                isShooting = (Input.GetMouseButton(1) && Input.GetMouseButtonDown(0) && SaveScript.hasWeapon);
                if (isShooting)
                {
                    flameStream.gameObject.SetActive(true);
                    if (rapidPlay)
                    {
                        rapidPlay = false;
                        fireFuel = true;
                        playerSounds.loop = true;
                        playerSounds.clip = flameSound;
                        playerSounds.Play();

                    }
                }


                if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0) || !SaveScript.hasWeapon)
                {
                    flameStream.gameObject.SetActive(false);
                    fireFuel = false;
                    rapidPlay = true;
                    playerSounds.loop = false;
                    playerSounds.Stop();
                }


                if (fireFuel)
                {
                    SaveScript.UpdateAmmo(4, ammoDecrease);
                }


            }


        }//end of !isPlayerDead
        else if(SaveScript.isPlayerDead && !isGameOver)
        {
            playerSounds.Stop();
            isGameOver = true;
            playerSounds.PlayOneShot(gameOverSound);
        }

    }

    private void Hits()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 1000, ~playerLayerMask))
        {
            if (hit.transform.CompareTag("Stone"))
            {
                Instantiate(stoneImpact,hit.point,Quaternion.LookRotation(hit.normal));
            }

            if (hit.transform.CompareTag("Metal"))
            {
                Instantiate(metalImpact, hit.point, Quaternion.LookRotation(hit.normal));
            }

            if (hit.transform.CompareTag("Explosive"))
            {
                hit.transform.gameObject.SendMessage("Explode");
               // Debug.Log("EXPLODE!");
            }

            if (hit.transform.CompareTag("Enemy"))
            {
                Instantiate(bloodImpact, hit.point, Quaternion.LookRotation(hit.normal));
                hit.transform.gameObject.SendMessage("TakeDamage");

            }else if (hit.transform.CompareTag("EnemyCap"))
            {
                aiZombieScript = hit.transform.gameObject.GetComponentInParent<AIZombie>();

                if (!aiZombieScript.isDead)
                {
                    Instantiate(bloodImpact, hit.point, Quaternion.LookRotation(hit.normal));
                    aiZombieScript.TakeDamage();
                }
            }

            if (hit.transform.CompareTag("Boss"))
            {
                Instantiate(bloodImpact, hit.point, Quaternion.LookRotation(hit.normal));
                hit.transform.gameObject.SendMessage("GetHit");
            }

        }

    }

    private IEnumerator RapidFire()
    {
        yield return new WaitForSeconds(rapidDelay);
        //Decrease Machine Gun ammo
        SaveScript.UpdateAmmo(2, ammoDecrease);

        Hits();
        shooting = true;
    }

    private IEnumerator Grenade()
    {
        float delayTime = 0.3f;
        yield return new WaitForSeconds(delayTime);
        Instantiate(grenadeExplosion, hit.point, Quaternion.LookRotation(hit.normal));
        playerSounds.PlayOneShot(grenadeSound);
        Hits();

        if (hit.transform.CompareTag("Explosive"))
        {
            hit.transform.gameObject.SendMessage("Explode");
        }

    }

    //Pick ups functionalities
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RifleAmmo"))
        {
            SaveScript.weaponID = 1;
            SaveScript.UpdateWeaponPickupInfo(1,30.0f);
            playerSounds.PlayOneShot(pickUpSound);
            Destroy(other.gameObject, 0.2f);
        }
        if (other.CompareTag("RapidFire"))
        {
            SaveScript.weaponID = 2;
            SaveScript.UpdateWeaponPickupInfo(2, 150.0f);
            playerSounds.PlayOneShot(pickUpSound);
            Destroy(other.gameObject, 0.2f);
        }
        if (other.CompareTag("GrenadeAmmo"))
        {
            SaveScript.UpdateWeaponPickupInfo(3, 3.0f);
            SaveScript.weaponID = 3;
            playerSounds.PlayOneShot(pickUpSound);
            Destroy(other.gameObject, 0.2f);
        }

        if (other.CompareTag("FlameAmmo"))
        {
            SaveScript.UpdateWeaponPickupInfo(4, 25.0f);
            SaveScript.weaponID = 4;
            playerSounds.PlayOneShot(pickUpSound);
            Destroy(other.gameObject, 0.2f);
        }

        if (other.CompareTag("HealthPickup"))
        {

            SaveScript.HealthPickup();
            playerSounds.PlayOneShot(pickUpSound);
            Destroy(other.gameObject);
        }

    }

 
}
