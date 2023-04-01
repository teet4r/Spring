using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Bee : MonoBehaviour, IDamageable
{
    public MovementController MovementController
    {
        get => _movementController;
    }

    [SerializeField] MovementController _movementController;

    [SerializeField] SpriteRenderer _spriteRenderer;

    bool _isInvincible;

    Coroutine _invincibleCoroutine;

    Coroutine _changingColorCoroutine;



    void OnEnable()
    {
        _StopInvincible();
        StopChangingColor();
    }

    void OnDisable()
    {
        _StopInvincible();
        StopChangingColor();
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

        SoundManager.Instance.PlaySfx(Sfx.DAMAGED);
        HeartManager.instance.GetDamaged(damage);
    }

    public void StartInvincible(float time)
    {
        _StopInvincible();

        StartCoroutine(_Invincible(time));
    }

    public void StartChangingColor(Color temperary)
    {
        if (_changingColorCoroutine != null)
            return;

        _changingColorCoroutine = StartCoroutine(_TemperatelySetColor(temperary));
    }

    public void StopChangingColor()
    {
        _spriteRenderer.material.color = Color.white;

        if (_changingColorCoroutine == null)
            return;

        _changingColorCoroutine = null;
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

    IEnumerator _TemperatelySetColor(Color temperary)
    {
        yield return _spriteRenderer.material.DOColor(temperary, 1f).WaitForCompletion();
        yield return _spriteRenderer.material.DOColor(Color.white, 1f).WaitForCompletion();

        _changingColorCoroutine = null;
    }
}
