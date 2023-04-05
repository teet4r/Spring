using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Item, IUsable
{
    public bool IsUsed
    {
        get => _isUsed;
    }

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

        SoundManager.Instance.PlaySfx(Sfx.USE_POWER);

        player.StartChangingColor(new Color(1f, 1f, 1f, 0.25f), 3f);
        player.StartInvincible(3f);

        Destroy(gameObject);
    }
}
