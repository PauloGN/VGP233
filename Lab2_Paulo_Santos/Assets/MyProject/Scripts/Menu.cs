using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI myHighScore;

    // Start is called before the first frame update
    void Start()
    {
        myHighScore.text = SaveHighScore.highScore.ToString("n0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        //Open The main Scene
        SceneManager.LoadScene(0);
    }

    //Game Buttons aplication

    public void ShowGameInfo()
    {
        //Open game information
        SceneManager.LoadScene(2);

    }

    public void Quit()
    {
        //Close the game aplication
        Application.Quit();
    }

}
