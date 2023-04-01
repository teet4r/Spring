using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public static HeartManager instance;

    [SerializeField] GameObject heart;
    [SerializeField] int heartNum;
    [SerializeField] Timer timer;
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


    // 게임 오버가 되면 처리해야할 것들
    // 1. 게임 타이머 멈추기
    // 2. 적 소환 멈추기 - CurrentHeart 프로퍼티를 가져간 어디선가 관리
    // 3. 게임 오버 UI 띄우기
    void GameOver()
    {
        timer.StopTimer();
        GameOverWindow.instance.ActivateWindow();
    }
}