using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShaking : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    [SerializeField] float _shakingTime;

    Coroutine _shakingCoroutine;

    Vector3 _originPosition;



    void Awake()
    {
        _originPosition = transform.position;
    }

    void OnEnable()
    {
        StopCamerashaking();
    }

    void OnDisable()
    {
        StopCamerashaking();
    }

    public void StartCameraShaking()
    {
        _shakingCoroutine = StartCoroutine(_CameraShaking());
    }

    public void StopCamerashaking()
    {
        if (_shakingCoroutine == null)
            return;

        StopCoroutine(_shakingCoroutine);

        _shakingCoroutine = null;
    }

    IEnumerator _CameraShaking()
    {
        yield return _mainCamera.DOShakePosition(_shakingTime, 30f).WaitForCompletion();
        yield return _mainCamera.transform.DOMove(_originPosition, 0.5f).WaitForCompletion();
    }
}
