using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item, IUsable
{
    void OnEnable()
    {
        _rigidbody.position = MainCamera.Instance.GetRandomPositionInCamera();
    }

    public void Use(Bee player)
    {
        SoundManager.Instance.PlaySfx(Sfx.USE_MAGNET);

        Destroy(gameObject);
    }
}