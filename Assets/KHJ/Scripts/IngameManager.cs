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



    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // �ܹ� ����
        _bee = Instantiate(_beePrefab);

        // ���� ����
        _hornetSpawner.StartSpawningHornet();

        // �� ����
        _flowerSpawner.StartSpawningFlower();

        // ������ ����
        _itemSpawner.StartSpawningItem();
    }

    void Update()
    {
        /*
        if (HeartManager.instance.CurrentHeart <= 0)
        {
            Destroy(_bee.gameObject);

            _hornetSpawner.StopSpawningHornet();
            _flowerSpawner.StopSpawningFlower();
            _itemSpawner.StopSpawningItem();
        }
        */
    }
}
