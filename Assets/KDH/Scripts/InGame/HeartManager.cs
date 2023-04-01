using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public static HeartManager instance;

    [SerializeField] GameObject heart;
    [SerializeField] int heartNum;
    Transform tr;

    private void Awake()
    {
        instance = this;
        tr = transform;
        InitHeart();
    }

    public void InitHeart()
    {
        for (int i = 0; i < heartNum; i++)
        {
            Instantiate(heart, tr);
        }
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