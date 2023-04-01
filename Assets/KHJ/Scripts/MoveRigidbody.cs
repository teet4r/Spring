using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveRigidbody : MonoBehaviour
{
    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    [SerializeField] Rigidbody2D _rigidbody;

    [SerializeField] float _speed;

    Coroutine _moveCoroutine;



    void OnEnable()
    {
        _moveCoroutine = null;
    }

    void OnDisable()
    {
        StopMove();
    }

    public void StartMove(Vector2 start, Vector2 end)
    {
        if (_moveCoroutine != null)
            return;

        _moveCoroutine = StartCoroutine(_MoveAToB(start, end));
    }

    public void StopMove()
    {
        if (_moveCoroutine == null)
            return;

        StopCoroutine(_moveCoroutine);

        _moveCoroutine = null;
    }

    IEnumerator _MoveAToB(Vector2 start, Vector2 end)
    {
        _rigidbody.position = start;

        while (_rigidbody.position != end)
        {
            _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, end, _speed * Time.deltaTime);

            yield return null;
        }

        _moveCoroutine = null;
    }
}
