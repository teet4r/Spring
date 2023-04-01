using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    public static GameOverWindow instance;

    [SerializeField] Text scoreText;
    [SerializeField] Text timeText;
    [SerializeField] Text highScoreText;

    [SerializeField] Timer timer;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        timeText.text = $"Time {timer.GameTime:F2} sec";
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", ScoreManager.instance.Score);
        }
        else
        {
            if (PlayerPrefs.GetInt("HighScore") < ScoreManager.instance.Score)
            {
                PlayerPrefs.SetInt("HighScore", ScoreManager.instance.Score);
            }
        }
        scoreText.text = $"{ScoreManager.instance.Score:N0}";
        highScoreText.text = $"Best Score : {PlayerPrefs.GetInt("HighScore"):N0}";
    }

    public void ActivateWindow()
    {
        gameObject.SetActive(true);
    }
}