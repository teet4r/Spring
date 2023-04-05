using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2 : MonoBehaviour, IPattern
{
    [SerializeField] HornetSpawner _hornetSpawner;



    void Awake()
    {
        _hornetSpawner.AddPattern(this);
    }

    public void Deploy()
    {
        var player = IngameManager.Instance.Player;

        for (int i = 0; i < 2; i++)
        {
            var clone = _hornetSpawner.SpawnHornet();

            var randomY = Random.Range(-MainCamera.CameraHalfHeight, MainCamera.CameraHalfHeight);

            var start = new Vector2(MainCamera.CameraHalfWidth + 100f, randomY);
            var mid = player == null ? Vector2.zero : player.MovementController.Position;
            var end = (mid - start).normalized * 1000f;

            clone.MoveRigidbody.StartMove(start, end, _hornetSpawner.HornetSpeed);
            clone.RotateRigidbody.StartLookAt(end);



            clone = _hornetSpawner.SpawnHornet();

            randomY = Random.Range(-MainCamera.CameraHalfHeight, MainCamera.CameraHalfHeight);

            start = new Vector2(-MainCamera.CameraHalfWidth - 100f, randomY);
            mid = player == null ? Vector2.zero : player.MovementController.Position;
            end = (mid - start).normalized * 1000f;

            clone.MoveRigidbody.StartMove(start, end, _hornetSpawner.HornetSpeed);
            clone.RotateRigidbody.StartLookAt(end);
        }
    }
}
