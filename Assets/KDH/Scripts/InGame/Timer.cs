using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timerText;
    float time = 0f;

    private void Awake()
    {
        timerText = GetComponent<Text>();
        RefreshTimerText();
    }

    private void Update()
    {
        time += Time.deltaTime;
        RefreshTimerText();
    }

    void RefreshTimerText()
    {
        timerText.text = $"{time:f2}√ ";
    }
}