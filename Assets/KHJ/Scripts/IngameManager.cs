using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public static IngameManager Instance;

    [SerializeField] Bee _beePrefab;

    [SerializeField] Hornet _enemyPrefab;

    [SerializeField] Flower _flowerPrefab;

    [SerializeField] Boom _boomPrefab;



    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // 曹国 积己
        Instantiate(_beePrefab);

        // 富国 积己
        StartCoroutine(_MakeHornet());

        // 采 积己
        //StartCoroutine(_MakeFlower());

        // 气藕 积己
        StartCoroutine(_MakeBoom());
    }

    IEnumerator _MakeHornet()
    {
        var wfs = new WaitForSeconds(0.25f);

        var spawnPosition = new Vector2(2000f, 2000f);

        while (true)
        {
            var clone = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);

            var start = Circle.GetOnUnitCirclePoint(Vector2.zero, Random.Range(0f, 360f)) * 1200f;
            var end = -start;

            clone.MoveRigidbody.StartMove(start, end);
            clone.RotateRigidbody.StartLookAt(end);
            clone.DestroyTimer.StartTimer();

            yield return wfs;
        }
    }

    IEnumerator _MakeFlower()
    {
        var wfs = new WaitForSeconds(2f);

        while (true)
        {
            Instantiate(_flowerPrefab);

            yield return wfs;
        }
    }

    IEnumerator _MakeBoom()
    {
        var wfs = new WaitForSeconds(3f);

        while (true)
        {
            Instantiate(_boomPrefab);

            yield return wfs;
        }
    }
}
