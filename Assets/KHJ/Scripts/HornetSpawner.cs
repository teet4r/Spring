using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetSpawner : MonoBehaviour
{
    public float HornetSpeed
    {
        get => _baseHornetSpeed * _speedMultiplier;
    }

    [SerializeField] Hornet _hornetPrefab;

    const float _baseHornetSpeed = 150f;

    float _speedMultiplier = 1f;

    int _makeCount = 1;

    bool _isStarted = false;

    Coroutine _spawningHornetCoroutine;

    Coroutine _spawnPatternCoroutine;
    
    Coroutine _speedAdderCoroutine;

    Coroutine _makeCountAdderCoroutine;

    List<IPattern> _patterns = new();



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
        _spawnPatternCoroutine = StartCoroutine(_SpawnPattern());
        _speedAdderCoroutine = StartCoroutine(_SpeedAdder());
        _makeCountAdderCoroutine = StartCoroutine(_MakeCountAdder());
    }

    public void StopSpawningHornet()
    {
        if (!_isStarted)
            return;

        _isStarted = false;

        StopCoroutine(_spawningHornetCoroutine);
        StopCoroutine(_spawnPatternCoroutine);
        StopCoroutine(_speedAdderCoroutine);
        StopCoroutine(_makeCountAdderCoroutine);
    }

    public Hornet SpawnHornet()
    {
        var clone = Instantiate(_hornetPrefab, new Vector2(3333f, 3333f), Quaternion.identity);

        return clone;
    }
    
    public void AddPattern(IPattern pattern)
    {
        _patterns.Add(pattern);
    }

    IEnumerator _SpawnHornet()
    {
        while (true)
        {
            for (int i = 0; i < _makeCount; i++)
            {
                var clone = SpawnHornet();

                var start = Circle.GetPointOnUnitCircle(Vector2.zero, Random.Range(0f, 360f)) * 800f;
                var end = Circle.GetPointOnUnitCircle(Vector2.zero, Random.Range(0f, 360f)) * 800f;
                
                clone.MoveRigidbody.StartMove(start, end, HornetSpeed);
                clone.RotateRigidbody.StartLookAt(end);

                yield return new WaitForSeconds(Random.Range(0f, 1f));
            }
            yield return new WaitForSeconds(Random.Range(3f, 5f));
        }
    }

    IEnumerator _SpawnPattern()
    {
        var wfs = new WaitForSeconds(10f);

        while (true)
        {
            yield return wfs;

            int idx = Random.Range(0, _patterns.Count);

            _patterns[idx].Deploy();
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
