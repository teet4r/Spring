using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1 : MonoBehaviour, IPattern
{
    [SerializeField] HornetSpawner _hornetSpawner;



    void Awake()
    {
        _hornetSpawner.AddPattern(this);
    }

    public void Deploy()
    {
        for (int i = 0; i < 4; i++)
        {
            var clone = _hornetSpawner.SpawnHornet();

            var randomY = Random.Range(-MainCamera.CameraHalfHeight, MainCamera.CameraHalfHeight);

            var start = new Vector2(MainCamera.CameraHalfWidth + 100f, randomY);
            var end = new Vector2(-MainCamera.CameraHalfWidth - 100f, randomY);

            clone.MoveRigidbody.StartMove(start, end, _hornetSpawner.HornetSpeed);
            clone.RotateRigidbody.StartLookAt(end);
        }
    }
}
