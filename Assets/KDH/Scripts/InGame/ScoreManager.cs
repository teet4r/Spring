using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] int score = 0;

    private void Update()
    {
        RefreshScoreText();
    }

    void RefreshScoreText()
    {
        scoreText.text = $"{score:N0}";
    }

    public void AddScore(int _score)
    {
        score += _score;
    }
}