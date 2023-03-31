using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody = default;

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

        _rigidbody.MovePosition(_rigidbody.position + dir * _speed * Time.deltaTime);
    }
}
