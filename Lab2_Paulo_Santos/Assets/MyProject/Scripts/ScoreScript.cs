using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI myFinalScore;
    private string finalScoreTXT = "Final Score: ";
    // Start is called before the first frame update
    void Start()
    {
        myFinalScore.text = finalScoreTXT + SaveScript.score.ToString("n0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
