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
    //Sounds
    private AudioSource playerSounds;
    [SerializeField]private AudioClip singleShoot;
    [SerializeField]private AudioClip rapidShoot;
    [SerializeField]private AudioClip grenadeSound;
    [SerializeField]private AudioClip flameSound;
    [SerializeField]private AudioClip pickUpSound;
    //variables of control
    private bool rapidPlay = true;
    private bool shooting = true;
    [SerializeField]private float rapidDelay = 0.2f;
    //Grenades
    [SerializeField] private GameObject grenadeSmoke;
    [SerializeField] private GameObject grenadeExplosion;
    //Fire
    [SerializeField] private GameObject flameStream;


    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        playerSounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        bool isShooting = false;
        //Regurlar Weeapon behavior
        if (SaveScript.weaponID == 1)
        {
            isShooting = (Input.GetMouseButton(1) && Input.GetMouseButtonDown(0));
            if (isShooting)
            {
                Instantiate(muzzleFlash, muzzleSpawn.position, muzzleSpawn.rotation);
                playerSounds.PlayOneShot(singleShoot);

                Hits();
            }
        }
        // Machine Gun behavior
        if (SaveScript.weaponID == 2)
        {
            isShooting = (Input.GetMouseButton(1) && Input.GetMouseButton(0));
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
                    shooting = false;
                    StartCoroutine(RapidFire());
                }

       
            }

            if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0))
            {
                rapidPlay = true;
                playerSounds.loop = false;
                playerSounds.pitch = 1;
                playerSounds.Stop();
            }

        }
        //Grenade 
        if (SaveScript.weaponID == 3)
        {
            isShooting = (Input.GetMouseButton(1) && Input.GetMouseButtonDown(0));
            if (isShooting)
            {
                //grenade effect when shooting
                Instantiate(grenadeSmoke, muzzleSpawn.position, muzzleSpawn.rotation);
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 1000))
                {
                    StartCoroutine(Grenade());
                }

            }
        }

        //FireStream Weap
        if (SaveScript.weaponID == 4)
        {
            isShooting = (Input.GetMouseButton(1) && Input.GetMouseButtonDown(0));
            if (isShooting)
            {
                flameStream.gameObject.SetActive(true);
                if (rapidPlay)
                {
                    rapidPlay = false;
                    playerSounds.loop = true;
                    playerSounds.clip = flameSound;
                    playerSounds.Play();

                }
            }


            if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0))
            {
                flameStream.gameObject.SetActive(false);
                rapidPlay = true;
                playerSounds.loop = false;
                playerSounds.Stop();
            }

        }


    }

    private void Hits()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out hit, 1000))
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

        }

    }

    private IEnumerator RapidFire()
    {
        yield return new WaitForSeconds(rapidDelay);
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
            SaveScript.UpdateWeaponPickupInfo(2, 30.0f);
            playerSounds.PlayOneShot(pickUpSound);
            Destroy(other.gameObject, 0.2f);
        }
        if (other.CompareTag("GrenadeAmmo"))
        {
            SaveScript.UpdateWeaponPickupInfo(3, 30.0f);
            SaveScript.weaponID = 3;
            playerSounds.PlayOneShot(pickUpSound);
            Destroy(other.gameObject, 0.2f);
        }

        if (other.CompareTag("FlameAmmo"))
        {
            SaveScript.UpdateWeaponPickupInfo(4, 30.0f);
            SaveScript.weaponID = 4;
            playerSounds.PlayOneShot(pickUpSound);
            Destroy(other.gameObject, 0.2f);
        }
    }

 
}
