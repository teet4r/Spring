using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Item, IUsable
{
    [SerializeField] GameObject _smokePrefab;

    void OnEnable()
    {
        _rigidbody.position = MainCamera.Instance.GetRandomPositionInCamera();
    }

    public void Use(Bee player)
    {
        SoundManager.Instance.PlaySfx(Sfx.USE_BOMB);

        MainCamera.Instance.CameraShaking.StartCameraShaking();

        Instantiate(_smokePrefab, Vector2.zero, Quaternion.identity);

        var hits = Physics2D.OverlapBoxAll(
            Vector2.zero,
            new Vector2(MainCamera.Instance.CameraHalfWidth * 2f, MainCamera.Instance.CameraHalfHeight * 2),
            0f
        );

        for (int i = 0; i < hits.Length; i++)
            if (hits[i] != null && hits[i].CompareTag("Enemy"))
                Destroy(hits[i].gameObject);

        Destroy(gameObject);
    }
}
