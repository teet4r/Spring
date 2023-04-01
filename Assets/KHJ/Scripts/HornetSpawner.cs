using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetSpawner : MonoBehaviour
{
    [SerializeField] Hornet _hornetPrefab;

    const float _baseHornetSpeed = 150f;

    float _speedMultiplier = 1f;

    int _makeCount = 1;

    bool _isStarted = false;

    Coroutine _spawningHornetCoroutine;
    
    Coroutine _speedAdderCoroutine;

    Coroutine _makeCountAdderCoroutine;



    void OnDisable()
    {
        StopSpawningHornet();
    }

    public void StartSpawningHornet()
    {
        if (_isStarted)
            return;

        _isStarted = true;

        _spawningHornetCoroutine = StartCoroutine(_SpawnHornet());
        _speedAdderCoroutine = StartCoroutine(_SpeedAdder());
        _makeCountAdderCoroutine = StartCoroutine(_MakeCountAdder());
    }

    public void StopSpawningHornet()
    {
        if (!_isStarted)
            return;

        _isStarted = false;

        StopCoroutine(_spawningHornetCoroutine);
        StopCoroutine(_speedAdderCoroutine);
        StopCoroutine(_makeCountAdderCoroutine);
    }

    IEnumerator _SpawnHornet()
    {
        var spawnPosition = new Vector2(3000f, 3000f);

        while (true)
        {
            for (int i = 0; i < _makeCount; i++)
            {
                var clone = Instantiate(_hornetPrefab, spawnPosition, Quaternion.identity);

                var start = Circle.GetOnUnitCirclePoint(Vector2.zero, Random.Range(0f, 360f)) * 1200f;
                var end = Circle.GetOnUnitCirclePoint(Vector2.zero, Random.Range(0f, 360f)) * 1200f;

                clone.MoveRigidbody.StartMove(start, end, _baseHornetSpeed * _speedMultiplier);
                clone.RotateRigidbody.StartLookAt(end);
                clone.DestroyTimer.StartTimer();

                yield return new WaitForSeconds(Random.Range(0f, 1f));
            }
            yield return new WaitForSeconds(Random.Range(3f, 5f));
        }
    }

    IEnumerator _SpeedAdder()
    {
        var wfs = new WaitForSeconds(10f);

        while (true)
        {
            yield return wfs;

            _speedMultiplier *= 1.25f;
        }
    }

    IEnumerator _MakeCountAdder()
    {
        var wfs = new WaitForSeconds(20f);

        while (true)
        {
            yield return wfs;

            _makeCount *= 2;
        }
    }
}
