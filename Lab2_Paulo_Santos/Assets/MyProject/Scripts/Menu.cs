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
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        myHighScore.text = SaveHighScore.highScore.ToString("n0");
    }

    public void Play()
    {
        //Open The main Scene
        SceneManager.LoadScene("Main_Scene");
    }

    //Game Buttons aplication

    public void ShowGameInfo()
    {
        //Open game information
        SceneManager.LoadScene("InfoMenu");

    }

    public void Quit()
    {
        //Close the game aplication
        Application.Quit();
    }

}
