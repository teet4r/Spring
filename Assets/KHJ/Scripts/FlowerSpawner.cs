using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField] Flower _flowerPrefab;

    bool _isStarted = false;

    Coroutine _spawningFlowerCoroutine;



    void OnDisable()
    {
        StopSpawningFlower();
    }

    public void StartSpawningFlower()
    {
        if (_isStarted)
            return;

        _isStarted = true;

        _spawningFlowerCoroutine = StartCoroutine(_MakeFlower());
    }

    public void StopSpawningFlower()
    {
        if (!_isStarted)
            return;

        _isStarted = false;

        StopCoroutine(_spawningFlowerCoroutine);
    }

    IEnumerator _MakeFlower()
    {
        var wfs = new WaitForSeconds(2f);

        while (true)
        {
            Instantiate(_flowerPrefab, new Vector2(3000f, 3000f), Quaternion.identity);

            yield return wfs;
        }
    }
}
