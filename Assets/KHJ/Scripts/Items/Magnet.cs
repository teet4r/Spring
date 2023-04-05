using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item, IUsable
{
    public bool IsUsed
    {
        get => _isUsed;
    }
    
    [SerializeField] DestroyTimer _timer;

    bool _isUsed = false;



    void OnEnable()
    {
        _rigidbody.position = MainCamera.Instance.GetRandomPositionInCamera(560f, 150f);
    }

    public void Use(Bee player)
    {
        if (IsUsed)
            return;

        _isUsed = true;

        _timer.StopTimer();

        SoundManager.Instance.PlaySfx(Sfx.USE_MAGNET);

        var hits = Physics2D.OverlapBoxAll(
            Vector2.zero,
            new Vector2(MainCamera.CameraHalfWidth * 2f, MainCamera.CameraHalfHeight * 2),
            0f
        );

        for (int i = 0; i < hits.Length; i++)
            if (hits[i] != null && hits[i].TryGetComponent(out Flower flower))
                flower.DestroyRoutine();

        Destroy(gameObject);
    }
}
