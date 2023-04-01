using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] Item[] _itemPrefabs;

    bool _isStarted = false;

    Coroutine _spawningItemCoroutine;



    void OnDisable()
    {
        StopSpawningItem();
    }

    public void StartSpawningItem()
    {
        if (_isStarted)
            return;

        _isStarted = true;

        _spawningItemCoroutine = StartCoroutine(_MakeItem());
    }

    public void StopSpawningItem()
    {
        if (!_isStarted)
            return;

        StopCoroutine(_spawningItemCoroutine);
    }

    IEnumerator _MakeItem()
    {
        var wfs = new WaitForSeconds(5f);

        while (true)
        {
            Instantiate(_itemPrefabs[Random.Range(0, _itemPrefabs.Length)], new Vector2(3000f, 3000f), Quaternion.identity);

            yield return wfs;
        }
    }
}
