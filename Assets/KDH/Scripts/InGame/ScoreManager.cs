using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] Text scoreText;
    [SerializeField] int score = 0;
    int timeScore = 0;

    public int Score { get { return score; } }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        RefreshScoreText();
    }

    void RefreshScoreText()
    {
        scoreText.text = $"{(score + timeScore):N0}";
    }

    public void AddScore(int _score)
    {
        score += _score;
    }

    public void SetTimeScore(float _time)
    {
        timeScore = ((int)_time / 10) * 500 + ((int)_time) * 10;
    }
}