using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern3 : MonoBehaviour, IPattern
{
    [SerializeField] HornetSpawner _hornetSpawner;



    void Awake()
    {
        _hornetSpawner.AddPattern(this);
    }

    public void Deploy()
    {
        StartCoroutine(_Deploy());
    }

    IEnumerator _Deploy()
    {
        var clone = _hornetSpawner.SpawnHornet();

        var randomX = Random.Range(-MainCamera.Instance.CameraHalfWidth, MainCamera.Instance.CameraHalfWidth);

        var start = new Vector2(randomX, MainCamera.Instance.CameraHalfHeight + 100f);
        var end = new Vector2(randomX, - MainCamera.Instance.CameraHalfHeight - 100f);

        clone.MoveRigidbody.StartMove(start, end, _hornetSpawner.HornetSpeed);
        clone.RotateRigidbody.StartLookAt(end);


        yield return new WaitForSeconds(1f);


        clone = _hornetSpawner.SpawnHornet();

        var randomY = Random.Range(-MainCamera.Instance.CameraHalfHeight, MainCamera.Instance.CameraHalfHeight);

        start = new Vector2(MainCamera.Instance.CameraHalfWidth + 100f, randomY);
        end = new Vector2(-MainCamera.Instance.CameraHalfWidth - 100f, randomY);

        clone.MoveRigidbody.StartMove(start, end, _hornetSpawner.HornetSpeed);
        clone.RotateRigidbody.StartLookAt(end);


        yield return new WaitForSeconds(1f);


        clone = _hornetSpawner.SpawnHornet();

        randomX = Random.Range(-MainCamera.Instance.CameraHalfWidth, MainCamera.Instance.CameraHalfWidth);

        start = new Vector2(randomX, -MainCamera.Instance.CameraHalfHeight - 100f);
        end = new Vector2(randomX, MainCamera.Instance.CameraHalfHeight + 100f);

        clone.MoveRigidbody.StartMove(start, end, _hornetSpawner.HornetSpeed);
        clone.RotateRigidbody.StartLookAt(end);


        yield return new WaitForSeconds(1f);


        clone = _hornetSpawner.SpawnHornet();

        randomY = Random.Range(-MainCamera.Instance.CameraHalfHeight, MainCamera.Instance.CameraHalfHeight);

        start = new Vector2(-MainCamera.Instance.CameraHalfWidth - 100f, randomY);
        end = new Vector2(MainCamera.Instance.CameraHalfWidth + 100f, randomY);

        clone.MoveRigidbody.StartMove(start, end, _hornetSpawner.HornetSpeed);
        clone.RotateRigidbody.StartLookAt(end);
    }
}
