using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void SelectGameStartButton()
    {
        SceneManager.LoadScene("InGame");
    }

    public void SelectGameExitButton()
    {
        Application.Quit();
    }
}