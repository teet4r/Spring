using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MovementController : MonoBehaviour
{
    [SerializeField] Camera _mainCamera = null;

    [SerializeField] Transform _tranform = default;

    [SerializeField] Rigidbody2D _rigidbody = default;

    [SerializeField] SpriteRenderer _spriteRenderer = default;

    [SerializeField] float _speed = default;

    float _vertical = default;

    float _horizontal = default;


    /*
    void Awake()
    {
        _mainCamera.orthographicSize = Screen.height >> 1;

        _halfHeight = _mainCamera.orthographicSize;
        _halfWidth = _halfHeight * _mainCamera.aspect;
    }

    void Update()
    {
        _vertical = Input.GetAxisRaw("Vertical");
        _horizontal = Input.GetAxisRaw("Horizontal");

        _Move();
        _FlipSpriteByMoveDirection();
    }

    void _Move()
    {
        var dir = (Vector2.up * _vertical + Vector2.right * _horizontal).normalized;
        var nextPosition = _rigidbody.position + dir * _speed * Time.deltaTime;
        var modifiedNextPosition = 
            MainCamera.Instance.ModifyPositionWithinCamera(
                nextPosition,
                _spriteRenderer.sprite,
                _tranform.localScale
            );

        _rigidbody.MovePosition(modifiedNextPosition);
    }

    Vector2 _LimitMoveWithinCamera(float worldPositionX, float worldPositionY, float spriteHalfHeight, float spriteHalfWidth)
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

    void _FlipSpriteByMoveDirection()
    {
        if (_horizontal < 0)
            _spriteRenderer.flipX = false;
        else if (_horizontal > 0)
            _spriteRenderer.flipX = true;
    }*/
}
    