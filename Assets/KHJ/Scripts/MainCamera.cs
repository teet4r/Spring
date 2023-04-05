using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public static MainCamera Instance;

    public static float CameraHalfHeight
    {
        get => _cameraHalfHeight;
    }

    public static float CameraHalfWidth
    {
        get => _cameraHalfWidth;
    }

    public CameraShaking CameraShaking
    {
        get => _cameraShaking;
    }

    [Header("References")]

    [SerializeField] Camera _mainCamera;

    [SerializeField] CameraShaking _cameraShaking;

    [Header("For Play Screen")]

    [SerializeField] Vector2 _playScreenCenter;

    [Min(0)][SerializeField] float _playScreenHalfHeight;

    [Min(0)][SerializeField] float _playScreenHalfWidth;

    [Header("For Fitting Screen")]

    [SerializeField] bool _synchronizeWithScreenSize;

    static float _cameraHalfHeight;

    static float _cameraHalfWidth;



    void Awake()
    {
        Instance = this;

        if (_synchronizeWithScreenSize)
            _mainCamera.orthographicSize = Screen.height >> 1;

        _cameraHalfHeight = _mainCamera.orthographicSize;
        _cameraHalfWidth = _cameraHalfHeight * _mainCamera.aspect;
    }

    public Vector2 GetRandomPositionInCamera()
    {
        return new Vector2(Random.Range(-CameraHalfWidth, CameraHalfWidth), Random.Range(-CameraHalfHeight, CameraHalfHeight));
    }

    public Vector2 GetRandomPositionInCamera(float xPadding, float yPadding)
    {
        return new Vector2(
            Random.Range(-CameraHalfWidth + xPadding, CameraHalfWidth - xPadding),
            Random.Range(-CameraHalfHeight + yPadding, CameraHalfHeight - yPadding)
        );
    }

    public bool IsInCamera(Vector2 position)
    {
        return -CameraHalfWidth <= position.x && position.x <= CameraHalfWidth &&
            -CameraHalfHeight <= position.y && position.y <= CameraHalfHeight;
    }
}
