using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MovementController : MonoBehaviour
{
    public Vector2 Position
    {
        get => _rigidbody.position;
    }

    [SerializeField] Transform _transform;

    [SerializeField] Rigidbody2D _rigidbody;

    [SerializeField] SpriteRenderer _spriteRenderer;

    [SerializeField] float _speed;

    [SerializeField] bool _limitMoveWithinMainCamera;

    [SerializeField] bool _activateFlipX;

    [SerializeField] bool _activateFlipY;

    float _vertical;

    float _horizontal;

    float _spriteHalfHeight;

    float _spriteHalfWidth;

    bool _originFlipX;

    bool _originFlipY;

    float _speedMultiplier = 1f;

    Coroutine _changeSpeedCoroutine;


    
    void Awake()
    {
        _spriteHalfHeight = _spriteRenderer.sprite.bounds.size.y / 2 * _transform.localScale.y;
        _spriteHalfWidth = _spriteRenderer.sprite.bounds.size.x / 2 * _transform.localScale.x;

        _originFlipX = _spriteRenderer.flipX;
        _originFlipY = _spriteRenderer.flipY;
    }

    void Update()
    {
        _vertical = Input.GetAxisRaw("Vertical");
        _horizontal = Input.GetAxisRaw("Horizontal");

        _Move();

        _FlipX();
        _FlipY();
    }

    void OnDisable()
    {
        _StopChangingSpeed();
    }

    public void StartChangingSpeed(float speedMultiplier, float time)
    {
        _StopChangingSpeed();

        _changeSpeedCoroutine = StartCoroutine(_ChangeSpeed(speedMultiplier, time));
    }

    void _Move()
    {
        var dir = (Vector2.up * _vertical + Vector2.right * _horizontal).normalized;
        var nextPosition = _rigidbody.position + dir * _speed * _speedMultiplier * Time.deltaTime;

        if (_limitMoveWithinMainCamera)
            nextPosition = _LimitMoveWithinCamera(nextPosition);

        _rigidbody.MovePosition(nextPosition);
    }

    Vector2 _LimitMoveWithinCamera(Vector2 curWorldPosition)
    {
        var x = Mathf.Clamp(
            curWorldPosition.x,
            -500f + _spriteHalfWidth,
            500f - _spriteHalfWidth
        );

        var y = Mathf.Clamp(
            curWorldPosition.y,
            -MainCamera.CameraHalfHeight + _spriteHalfHeight,
            MainCamera.CameraHalfHeight - _spriteHalfHeight
        );

        return new Vector2(x, y);
    }

    void _FlipX()
    {
        if (!_activateFlipX) return;

        if (_horizontal < 0)
            _spriteRenderer.flipX = _originFlipX;
        else if (_horizontal > 0)
            _spriteRenderer.flipX = !_originFlipX;
    }

    void _FlipY()
    {
        if (!_activateFlipY) return;

        if (_vertical < 0)
            _spriteRenderer.flipY = _originFlipY;
        else if (_vertical > 0)
            _spriteRenderer.flipY = !_originFlipY;
    }

    IEnumerator _ChangeSpeed(float speedMultiplier, float time)
    {
        _speedMultiplier = speedMultiplier;

        yield return new WaitForSeconds(time);

        _speedMultiplier = 1f;
    }

    void _StopChangingSpeed()
    {
        _speedMultiplier = 1f;

        if (_changeSpeedCoroutine != null)
            StopCoroutine(_changeSpeedCoroutine);

        _changeSpeedCoroutine = null;
    }
}
    