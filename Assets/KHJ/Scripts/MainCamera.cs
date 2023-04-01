using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public static MainCamera Instance;

    public float CameraHalfHeight
    {
        get => _cameraHalfHeight;
    }

    public float CameraHalfWidth
    {
        get => _cameraHalfWidth;
    }

    [SerializeField] Camera _mainCamera;

    [SerializeField] bool _synchronizeWithScreenSize;

    float _cameraHalfHeight;

    float _cameraHalfWidth;



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

    public bool IsInCamera(Vector2 position)
    {
        return -CameraHalfWidth <= position.x && position.x <= CameraHalfWidth &&
            -CameraHalfHeight <= position.y && position.y <= CameraHalfHeight;
    }
}
