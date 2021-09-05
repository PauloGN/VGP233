using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieFX : MonoBehaviour
{

    [SerializeField] private Material dissolveMat;
    [SerializeField] private GameObject particleFX;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = dissolveMat;
        particleFX.gameObject.SetActive(true);
        GetComponent<SpawnEffect>().enabled = true;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
