using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InfoMenu : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;
    }

    // Back to menu
    public void MainMenu()
    {
        //Open The main menu
        SceneManager.LoadScene("MainMenu");
    }
}
