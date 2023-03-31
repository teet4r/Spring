using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public static HeartManager instance;

    [SerializeField] GameObject heartImage;
    Transform tr;
    int stage;
    int heart;

    private void Awake()
    {
        instance = this;
        tr = transform;
    }

    // InitHeart(int) - �������� ������ �� ȣ��
    // ���� ���ڴ� ���̵��� �����Ǹ� ���ڿ� ���� �ִ� ���� ������ ���Ѵ�.
    public void InitHeart(int _stage)
    {
        stage = _stage;
        SetHeartNum();
        for (int i = 0; i < heart; i++)
        {
            Instantiate(heartImage, tr);
        }
    }

    void SetHeartNum()
    {
        heart = 4 - stage;
    }

    public void GetDamaged()
    {
        for (int i = heart - 1; i >= 0; i++)
        {
            Heart _heart = tr.GetChild(i).GetComponent<Heart>();
            if (_heart.IsFilled)
            {
                _heart.BreakHeart();
            }
        }
    }
}