using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveHighScore : MonoBehaviour
{

    public static int highScore = 0;
    public bool setScore;
    [SerializeField] private GameObject scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        setScore = false;
        DontDestroyOnLoad(scoreKeeper);
        highScore = PlayerPrefs.GetInt("New High Score");
    }

    // Update is called once per frame
    void Update()
    {

        if (SaveScript.winScore)
        {
            setScore = true;
        }

        if (setScore)
        {
            setScore = false;

            if (SaveScript.score > highScore)
            {
                PlayerPrefs.SetInt("New High Score", SaveScript.score);
                PlayerPrefs.Save();
            }
        }


    }
}
