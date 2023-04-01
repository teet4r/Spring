using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
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
        image.color = Color.black;
    }

    public void FillHeart()
    {
        isFilled = true;
        image.color = Color.white;
    }
}