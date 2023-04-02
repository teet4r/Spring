using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item, IUsable
{
    [SerializeField] DestroyTimer _timer;



    void OnEnable()
    {
        _rigidbody.position = MainCamera.Instance.GetRandomPositionInCamera();
    }

    public void Use(Bee player)
    {
        _timer.StopTimer();

        SoundManager.Instance.PlaySfx(Sfx.USE_MAGNET);

        var hits = Physics2D.OverlapBoxAll(
            Vector2.zero,
            new Vector2(MainCamera.Instance.CameraHalfWidth * 2f, MainCamera.Instance.CameraHalfHeight * 2),
            0f
        );

        for (int i = 0; i < hits.Length; i++)
            if (hits[i] != null && hits[i].TryGetComponent(out Flower flower))
                flower.DestroyRoutine();

        Destroy(gameObject);
    }
}
