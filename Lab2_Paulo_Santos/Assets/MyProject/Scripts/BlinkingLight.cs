using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class BlinkingLight : MonoBehaviour
{
    [SerializeField] private GameObject spotLight;
    private bool onOff = true;
    private float delay = 0.0f;
    private float delayMin = 0.3f;
    private float delayMax = 3.0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  
    void Update()
    {
        if (onOff)
        {
            onOff = false;
            StartCoroutine(TurnOnTurnOff());
        }
    }

   
    IEnumerator TurnOnTurnOff()
    {

        delay = Random.Range(delayMin, delayMax);
        //on
        yield return new WaitForSeconds(delay);
        spotLight.SetActive(true);

        delay = Random.Range(delayMin, delayMax);
        yield return new WaitForSeconds(delay);
        //off
        spotLight.SetActive(false);
        onOff = true;

    }

}
