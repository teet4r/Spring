using UnityEngine;

public class Hornet : Enemy, IDamageable
{
    public MoveRigidbody MoveRigidbody
    {
        get => _moveRigidbody;
    }

    public RotateRigidbody RotateRigidbody
    {
        get => _rotateRigidbody;
    }

    public DestroyTimer DestroyTimer
    {
        get => _destroyTimer;
    }

    [SerializeField] MoveRigidbody _moveRigidbody;

    [SerializeField] RotateRigidbody _rotateRigidbody;

    [SerializeField] DestroyTimer _destroyTimer;



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bee bee))
        {
            bee.GetDamage(1);
            GetDamage(1000);
        }
    }

    public void GetDamage(int damage)
    {
        Destroy(gameObject);
    }
}
