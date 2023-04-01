using System.Collections;
using UnityEngine;

public class Bee : MonoBehaviour, IDamageable
{
    public MovementController MovementController
    {
        get => _movementController;
    }

    [SerializeField] MovementController _movementController;

    bool _isInvincible;

    Coroutine _invincibleCoroutine;



    void OnEnable()
    {
        _StopInvincible();
    }

    void OnDisable()
    {
        _StopInvincible();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IUsable item))
            item.Use(this);
    }

    public void GetDamage(int damage)
    {
        if (_isInvincible)
            return;

        HeartManager.instance.GetDamaged(damage);
    }

    public void StartInvincible(float time)
    {
        _StopInvincible();

        StartCoroutine(_Invincible(time));
    }

    void _StopInvincible()
    {
        _isInvincible = false;

        if (_invincibleCoroutine == null)
            return;

        StopCoroutine(_invincibleCoroutine);
    }

    IEnumerator _Invincible(float time)
    {
        _isInvincible = true;

        yield return new WaitForSeconds(time);

        _isInvincible = false;
    }
}
