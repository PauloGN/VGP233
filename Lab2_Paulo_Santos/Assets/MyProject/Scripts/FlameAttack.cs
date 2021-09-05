using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAttack : MonoBehaviour
{


    [SerializeField] GameObject burnOutFX;
    private AIZombie aIZombieScript;
    private float delayTime = 0.0f;
    private const float resetDelay = 0.5f;


    private void Start()
    {
        aIZombieScript = GetComponentInParent<AIZombie>();
    }

    private void OnParticleCollision(GameObject other)
    {

        delayTime -= Time.deltaTime;

        if (!aIZombieScript.isDead && delayTime <= 0.0f)
        {
            gameObject.SendMessageUpwards("TakeDamage");
            //aIZombieScript.TakeDamage();
            // Debug.Log("Is burning......");

            burnOutFX.SetActive(true);
            delayTime = resetDelay;
        }

    }

}
