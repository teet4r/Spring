using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public static HeartManager instance;

    [SerializeField] GameObject heart;
    [SerializeField] int heartNum;
    Transform tr;

    public int CurrentHeart { get { return heartNum; } }

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

    public void GetDamaged(int _damage)
    {
        for (int i = 0; i < _damage; i++)
        {
            for (int j = heartNum - 1; j >= 0; j--)
            {
                Heart _heart = tr.GetChild(j).GetComponent<Heart>();
                if (_heart.IsFilled)
                {
                    _heart.BreakHeart();
                    break;
                }
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