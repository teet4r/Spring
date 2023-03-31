using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MovementController : MonoBehaviour
{
    [SerializeField] Transform _tranform = default;

    [SerializeField] Rigidbody2D _rigidbody = default;

    [SerializeField] SpriteRenderer _spriteRenderer = default;

    [SerializeField] float _speed = default;

    float _vertical = default;

    float _horizontal = default;



    void Update()
    {
        _vertical = Input.GetAxisRaw("Vertical");
        _horizontal = Input.GetAxisRaw("Horizontal");

        _Move();
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
}
