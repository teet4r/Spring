using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
    Text timerText;
    float timerTime = 0f;

    private void Awake()
    {
        timerText = GetComponent<Text>();
    }

    private void Start()
    {
        StartCoroutine(PlayTimerText());
    }

    IEnumerator PlayTimerText()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        timerText.text = "3";
        yield return new WaitForSecondsRealtime(0.5f);
        timerText.text = "2";
        yield return new WaitForSecondsRealtime(0.5f);
        timerText.text = "1";
        yield return new WaitForSecondsRealtime(0.5f);
        timerText.text = "Start!";
        timerText.color = new Color(1f, 0.45f, 0f);
        yield return new WaitForSecondsRealtime(0.5f);
        timerText.text = "";
        yield break;
    }
}