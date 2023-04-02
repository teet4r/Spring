using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [Min(0f)][SerializeField] float _time;

    Coroutine _timerCoroutine;



    void OnEnable()
    {
        _timerCoroutine = null;

        StartTimer();
    }

    void OnDisable()
    {
        StopTimer();
    }

    public void StartTimer()
    {
        if (_timerCoroutine != null)
            return;

        _timerCoroutine = StartCoroutine(_Timer(_time));
    }

    public void StopTimer()
    {
        if (_timerCoroutine == null)
            return;

        StopCoroutine(_timerCoroutine);

        _timerCoroutine = null;
    }

    IEnumerator _Timer(float time)
    {
        var wfs = new WaitForSeconds(time);

        yield return wfs;

        Destroy(gameObject);
    }
}
