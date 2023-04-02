using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flower : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;

    [SerializeField] DestroyTimer _timer;

    [SerializeField] int _score;

    Coroutine _destroyCoroutine;



    void OnEnable()
    {
        _rigidbody.position = MainCamera.Instance.GetRandomPositionInCamera();
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

    void _TriggerCondition(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bee player))
            DestroyRoutine();
    }

    public void DestroyRoutine()
    {
        if (_destroyCoroutine != null)
            return;

        _destroyCoroutine = StartCoroutine(_DestroyRoutine());
    }

    IEnumerator _DestroyRoutine()
    {
        _timer.StopTimer();

        yield return _rigidbody.DOMove(new Vector2(0f, 430f), 1f).WaitForCompletion();

        SoundManager.Instance.PlaySfx(Sfx.FLOWER_GET);
        ScoreManager.instance.AddScore(_score);
        FlowerManager.instance.AcquireFlower();

        Destroy(gameObject);
    }
}
