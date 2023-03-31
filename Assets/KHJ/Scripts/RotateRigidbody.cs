using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RotateRigidbody : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;

    Coroutine _lookAtCoroutine;

    bool _lookAt;



    void OnEnable()
    {
        _lookAtCoroutine = null;
        _lookAt = false;
    }

    void OnDisable()
    {
        StopLookAt();
    }

    public void StartLookAt(Vector2 target)
    {
        if (_lookAtCoroutine != null)
            return;

        _lookAt = true;
        _lookAtCoroutine = StartCoroutine(_LookAt(target));
    }

    public void StopLookAt()
    {
        if (_lookAtCoroutine == null)
            return;

        _lookAt = false;
        _lookAtCoroutine = null;
    }

    IEnumerator _LookAt(Vector2 target)
    {
        while (_lookAt)
        {
            var angle = Mathf.Atan2(target.y - _rigidbody.position.y, target.x - _rigidbody.position.x) * Mathf.Rad2Deg;

            _rigidbody.rotation = angle - 90;

            yield return null;
        }

        _lookAtCoroutine = null;
    }
}
