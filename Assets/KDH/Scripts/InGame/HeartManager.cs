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

    // InitHeart(int) - 스테이지 시작할 때 호출
    // 받은 인자는 난이도로 설정되며 인자에 따라 최대 생명 개수가 변한다.
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