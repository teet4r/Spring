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
        player.StartChangingColor(Color.yellow);
        player.StartInvincible(2f);
        player.MovementController.StartChangeSpeed(1.5f, 2f);

        Destroy(gameObject);
    }
}
