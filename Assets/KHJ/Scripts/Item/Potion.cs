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
        Debug.Log("도로롱 체력 회복!!");
        //HeartManager.instance.RestoreHeart();

        Destroy(gameObject);
    }
}
