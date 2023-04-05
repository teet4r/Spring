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
        _TriggerCondition(collision);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        _TriggerCondition(collision);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        _TriggerCondition(collision);
    }

    public void GetDamage(int damage)
    {
        if (_isInvincible)
            return;

        StartInvincible(1.5f);

        SoundManager.Instance.PlaySfx(Sfx.DAMAGED);
        HeartManager.instance.GetDamaged(damage);
    }

    public void StartInvincible(float time)
    {
        _StopInvincible();

        StartCoroutine(_Invincible(time));
    }

    public void StartChangingColor(Color temperary, float totalChangingTime)
    {
        if (_changingColorCoroutine != null)
            return;

        _changingColorCoroutine = StartCoroutine(_TemperatelySetColor(temperary, totalChangingTime));
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

    IEnumerator _TemperatelySetColor(Color temperary, float totalChangingTime)
    {
        yield return _spriteRenderer.material.DOColor(temperary, totalChangingTime / 2f).WaitForCompletion();
        yield return _spriteRenderer.material.DOColor(Color.white, totalChangingTime / 2f).WaitForCompletion();

        _changingColorCoroutine = null;
    }

    void _TriggerCondition(Collider2D collision)
    {
        if (collision.TryGetComponent(out IUsable item))
            item.Use(this);
    }
}
