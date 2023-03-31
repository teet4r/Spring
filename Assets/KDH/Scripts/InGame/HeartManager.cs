using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public static HeartManager instance;

    [SerializeField] GameObject heart;
    Transform tr;
    int stage;
    int heartNum;

    private void Awake()
    {
        instance = this;
        tr = transform;
        InitHeart(1);
    }

    // InitHeart(int) - �������� ������ �� ȣ��
    // ���� ���ڴ� ���̵��� �����Ǹ� ���ڿ� ���� �ִ� ���� ������ ���Ѵ�.
    public void InitHeart(int _stage)
    {
        stage = _stage;
        SetHeartNum();
        for (int i = 0; i < heartNum; i++)
        {
            Instantiate(heart, tr);
        }
    }

    void SetHeartNum()
    {
        heartNum = 4 - stage;
    }

    public void GetDamaged()
    {
        for (int i = heartNum - 1; i >= 0; i--)
        {
            Heart _heart = tr.GetChild(i).GetComponent<Heart>();
            if (_heart.IsFilled)
            {
                _heart.BreakHeart();
                break;
            }
        }
    }

    public void RestoreHeart()
    {
        for (int i = 0; i < heartNum; i++)
        {
            Heart _heart = tr.GetChild(i).GetComponent<Heart>();
            if (!_heart.IsFilled)
            {
                _heart.FillHeart();
                break;
            }
        }
    }
}