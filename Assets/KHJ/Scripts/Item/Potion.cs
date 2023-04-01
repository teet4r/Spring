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
        Debug.Log("���η� ü�� ȸ��!!");
        //HeartManager.instance.RestoreHeart();

        Destroy(gameObject);
    }
}
