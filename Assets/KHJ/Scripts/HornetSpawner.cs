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
        float spawnRate = 3f;

        while (true)
        {
            for (int i = 0; i < _makeCount; i++)
            {
                var clone = SpawnHornet();

                var startAngle = Random.Range(0f, 360f);
                var endAngle = startAngle + 180f;

                var start = Circle.GetPointOnUnitCircle(Vector2.zero, startAngle) * 1200f;
                var end = Circle.GetPointOnUnitCircle(Vector2.zero, Random.Range(endAngle - 22.5f, endAngle + 22.5f)) * 1200f;
                
                clone.MoveRigidbody.StartMove(start, end, HornetSpeed);
                clone.RotateRigidbody.StartLookAt(end);

                yield return null;
            }

            spawnRate *= 0.95f;

            yield return new WaitForSeconds(Mathf.Max(spawnRate, 0.5f));
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

            _speedMultiplier *= 1.2f;
        }
    }

    IEnumerator _MakeCountAdder()
    {
        var wfs = new WaitForSeconds(8f);

        while (true)
        {
            yield return wfs;

            _makeCount = (int)(_makeCount * 1.3f);
        }
    }
}
