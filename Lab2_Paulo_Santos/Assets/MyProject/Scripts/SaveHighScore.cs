using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHighScore : MonoBehaviour
{

    public static int highScore;
    [SerializeField] private GameObject scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(scoreKeeper);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
