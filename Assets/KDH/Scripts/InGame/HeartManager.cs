using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public static HeartManager instance;

    [SerializeField] GameObject heart;
    [SerializeField] int heartNum;
    [SerializeField] Timer timer;
    [SerializeField] GameObject gameOverWindow;
    Transform tr;
    int currentHeart;

    public int CurrentHeart { get { return currentHeart; } }

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
        currentHeart = heartNum;
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
                    currentHeart--;
                    if (currentHeart <= 0)
                    {
                        GameOver();
                    }
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

    void GameOver()
    {
        timer.StopTimer();
        gameOverWindow.SetActive(true);
    }
}