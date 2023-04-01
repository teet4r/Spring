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
        yield return new WaitForSeconds(1f);
        tmpObject = Instantiate(countDownText, tr);
        tmpObject.GetComponent<CountDownText>().SetText("3");
        SoundManager.Instance.PlaySfx(Sfx.COUNTDOWN_BEEP);
        yield return new WaitForSeconds(1f);
        tmpObject = Instantiate(countDownText, tr);
        tmpObject.GetComponent<CountDownText>().SetText("2");
        SoundManager.Instance.PlaySfx(Sfx.COUNTDOWN_BEEP);
        yield return new WaitForSeconds(1f);
        tmpObject = Instantiate(countDownText, tr);
        tmpObject.GetComponent<CountDownText>().SetText("1");
        SoundManager.Instance.PlaySfx(Sfx.COUNTDOWN_BEEP);
        yield return new WaitForSeconds(1f);
        Instantiate(startText, tr);
        SoundManager.Instance.PlaySfx(Sfx.COUNTDOWN);
        yield return new WaitForSeconds(1f);
        timer.StartTimer();
        yield break;
    }
}