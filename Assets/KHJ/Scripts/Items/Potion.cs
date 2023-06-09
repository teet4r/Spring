using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item, IUsable
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

        SoundManager.Instance.PlaySfx(Sfx.USE_POTION);

        HeartManager.instance.RestoreHeart();

        player.StartChangingColor(Color.green, 2f);

        Destroy(gameObject);
    }
}
