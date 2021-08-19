using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultButton : MonoBehaviour
{

    private Button button;
    //Game Manager REF
    private GameManager gameManagerRef;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficult);
        gameManagerRef = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void SetDifficult()
    {        
        gameManagerRef.StartGame(difficulty);
    }
}
