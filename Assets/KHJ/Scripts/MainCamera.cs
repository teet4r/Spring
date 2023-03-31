using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public static MainCamera Instance = null;

    public float HalfHeight
    {
        get => _halfHeight;
    }

    public float HalfWidth
    {
        get => _halfWidth;
    }

    [SerializeField] Camera _camera = null;

    float _halfHeight = default;

    float _halfWidth = default;



    void Awake()
    {
        Instance = this;

        _camera.orthographicSize = Screen.height >> 1;

        _halfHeight = _camera.orthographicSize;
        _halfWidth = _halfHeight * _camera.aspect;
    }

    public Vector2 ModifyPositionWithinCamera(float worldPositionX, float worldPositionY, float spriteHalfHeight, float spriteHalfWidth)
    {
        var x = Mathf.Clamp(
            worldPositionX,
            -HalfWidth + spriteHalfWidth,
            HalfWidth - spriteHalfWidth
        );

        var y = Mathf.Clamp(
            worldPositionY,
            -HalfHeight + spriteHalfHeight,
            HalfHeight - spriteHalfHeight
        );

        return new Vector2(x, y);
    }

    public Vector2 ModifyPositionWithinCamera(Vector2 worldPosition, float spriteHalfHeight, float spriteHalfWidth)
    {
        return ModifyPositionWithinCamera(worldPosition.x, worldPosition.y, spriteHalfHeight, spriteHalfWidth);
    }

    public bool IsOutOfCamera()
    {
        return true;
    }
}
