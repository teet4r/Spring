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

    IEnumerator PlayTimer()
    {
        while (true)
        {
            gameTime += Time.deltaTime;
            ScoreManager.instance.SetTimeScore(gameTime);
            RefreshTimerText();
            yield return null;
        }
    }

    public void StartTimer()
    {
        StartCoroutine(PlayTimer());
    }

    public void StopTimer()
    {
        StopCoroutine(PlayTimer());
    }

    void RefreshTimerText()
    {
        timerText.text = $"{gameTime:f2} sec";
    }
}