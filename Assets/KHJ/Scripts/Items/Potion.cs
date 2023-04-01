using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item, IUsable
{
    void OnEnable()
    {
        _rigidbody.position = MainCamera.Instance.GetRandomPositionInCamera();
    }

    public void Use(Bee player)
    {
        SoundManager.Instance.PlaySfx(Sfx.USE_POTION);

        HeartManager.instance.RestoreHeart();

        player.StartChangingColor(Color.green);

        Destroy(gameObject);
    }
}
