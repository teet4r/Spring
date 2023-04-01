using UnityEngine;

public class Hornet : MonoBehaviour
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
        if (collision.CompareTag("Player"))
            Destroy(gameObject);
    }
}
