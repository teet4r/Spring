using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveRigidbody : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;

    Coroutine _moveCoroutine;



    void OnEnable()
    {
        _moveCoroutine = null;
    }

    void OnDisable()
    {
        StopMove();
    }

    public void StartMove(Vector2 start, Vector2 end, float speed)
    {
        if (_moveCoroutine != null)
            return;

        _moveCoroutine = StartCoroutine(_MoveAToB(start, end, speed));
    }

    public void StopMove()
    {
        if (_moveCoroutine == null)
            return;

        StopCoroutine(_moveCoroutine);

        _moveCoroutine = null;
    }

    IEnumerator _MoveAToB(Vector2 start, Vector2 end, float speed)
    {
        _rigidbody.position = start;

        while (_rigidbody.position != end)
        {
            _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, end, speed * Time.deltaTime);

            yield return null;
        }

        _moveCoroutine = null;
    }
}
