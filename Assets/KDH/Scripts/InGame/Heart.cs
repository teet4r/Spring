using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    [SerializeField] Sprite filledHeart;
    [SerializeField] Sprite emptyHeart;

    Image image;
    bool isFilled = true;

    public bool IsFilled { get { return isFilled; } }

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void BreakHeart()
    {
        isFilled = false;
        image.sprite = emptyHeart;
    }
}