using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InfoMenu : MonoBehaviour
{
    // Back to menu
    public void MainMenu()
    {
        //Open The main menu
        SceneManager.LoadScene(1);
    }
}
