using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
    Transform tr;
    [SerializeField] GameObject countDownText;
    [SerializeField] GameObject startText;
    [SerializeField] Timer timer;

    private void Awake()
    {
        tr = transform;
    }

    private void Start()
    {
        StartCoroutine(PlayTimerText());
    }

    IEnumerator PlayTimerText()
    {
        GameObject tmpObject;
        SoundManager.Instance.PlaySfx(Sfx.COUNTDOWN);
        yield return new WaitForSecondsRealtime(0.4f);
        tmpObject = Instantiate(countDownText, tr);
        tmpObject.GetComponent<CountDownText>().SetText("3");
        yield return new WaitForSecondsRealtime(0.95f);
        tmpObject = Instantiate(countDownText, tr);
        tmpObject.GetComponent<CountDownText>().SetText("2");
        yield return new WaitForSecondsRealtime(0.95f);
        tmpObject = Instantiate(countDownText, tr);
        tmpObject.GetComponent<CountDownText>().SetText("1");
        yield return new WaitForSecondsRealtime(0.95f);
        Instantiate(startText, tr);
        yield return new WaitForSecondsRealtime(1f);
        timer.StartTimer();
        yield break;
    }
}