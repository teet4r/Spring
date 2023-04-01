using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Item, IUsable
{
    void OnEnable()
    {
        _rigidbody.position = MainCamera.Instance.GetRandomPositionInCamera();
    }

    public void Use(Bee player)
    {
        SoundManager.Instance.PlaySfx(Sfx.USE_POWER);

        player.StartChangingColor(new Color(1f, 1f, 1f, 0.25f));
        player.StartInvincible(2f);
        player.MovementController.StartChangeSpeed(1.5f, 2f);

        Destroy(gameObject);
    }
}
