using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public static IngameManager Instance;

    [SerializeField] Bee _beePrefab;

    [SerializeField] HornetSpawner _hornetSpawner;

    [SerializeField] FlowerSpawner _flowerSpawner;

    [SerializeField] ItemSpawner _itemSpawner;

    Bee _bee;

    bool _isGameover = false;



    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // 曹国 积己
        _bee = Instantiate(_beePrefab);

        // 富国 积己
        _hornetSpawner.StartSpawningHornet();

        // 采 积己
        _flowerSpawner.StartSpawningFlower();

        // 酒捞袍 积己
        _itemSpawner.StartSpawningItem();
    }

    void Update()
    {
        if (_isGameover)
            return;

        if (HeartManager.instance.CurrentHeart <= 0)
        {
            _isGameover = true;
            
            Destroy(_bee.gameObject);

            _hornetSpawner.StopSpawningHornet();
            _flowerSpawner.StopSpawningFlower();
            _itemSpawner.StopSpawningItem();
        }
    }
}
