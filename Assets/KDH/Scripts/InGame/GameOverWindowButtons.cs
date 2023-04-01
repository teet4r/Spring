using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWindowButtons : MonoBehaviour
{
    public void SelectReplayButton()
    {
        SceneManager.LoadScene("InGame");
    }

    public void SelectMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}