using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public static IngameManager Instance;

    [SerializeField] Bee _beePrefab;

    [SerializeField] Flower _flowerPrefab;

    [SerializeField] Boom _boomPrefab;

    [SerializeField] Star _starPrefab;

    [SerializeField] Potion _potionPrefab;

    [SerializeField] Magnet _magnetPrefab;

    [SerializeField] HornetSpawner _hornetSpawner;



    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // �ܹ� ����
        Instantiate(_beePrefab);

        // ���� ����
        _hornetSpawner.StartSpawningHornet();

        // �� ����
        //StartCoroutine(_MakeFlower());

        // ��ź ����
        //StartCoroutine(_MakeBoom());

        // ��Ÿ ����
        //StartCoroutine(_MakeStar());

        // ���� ����
        //StartCoroutine(_MakePotion());

        // �ڼ� ����
        //StartCoroutine(_MakeMagnet());
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

    IEnumerator _MakeBoom()
    {
        var wfs = new WaitForSeconds(3f);

        while (true)
        {
            Instantiate(_boomPrefab, new Vector2(3000f, 3000f), Quaternion.identity);

            yield return wfs;
        }
    }

    IEnumerator _MakeStar()
    {
        var wfs = new WaitForSeconds(5f);

        while (true)
        {
            Instantiate(_starPrefab, new Vector2(3000f, 3000f), Quaternion.identity);

            yield return wfs;
        }
    }

    IEnumerator _MakePotion()
    {
        var wfs = new WaitForSeconds(5f);

        while (true)
        {
            Instantiate(_potionPrefab, new Vector2(3000f, 3000f), Quaternion.identity);

            yield return wfs;
        }
    }

    IEnumerator _MakeMagnet()
    {
        var wfs = new WaitForSeconds(5f);

        while (true)
        {
            Instantiate(_magnetPrefab, new Vector2(3000f, 3000f), Quaternion.identity);

            yield return wfs;
        }
    }
}
