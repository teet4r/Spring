using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public static IngameManager Instance;

    [SerializeField] Bee _beePrefab;

    [SerializeField] Hornet _enemyPrefab;



    void Awake()
    {
        Instance = this;
    }

    IEnumerator Start()
    {
        // 曹国 积己

        var beeClone = Instantiate(_beePrefab);
        beeClone.name = _beePrefab.name;

        // 富国 积己

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
}
