using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timerText;
    float gameTime = 0f;

    public float GameTime { get { return gameTime; } }

    private void Awake()
    {
        timerText = GetComponent<Text>();
        RefreshTimerText();
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
        ScoreManager.instance.SetTimeScore(gameTime);
        RefreshTimerText();
    }

    void RefreshTimerText()
    {
        timerText.text = $"{gameTime:f2}√ ";
    }
}