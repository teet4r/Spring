using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerNumText : MonoBehaviour
{
    Text flowerNumText;

    private void Awake()
    {
        flowerNumText = GetComponent<Text>();
    }

    private void Update()
    {
        RefreshFlowerNumText();
    }

    void RefreshFlowerNumText()
    {
        flowerNumText.text = $"x {FlowerManager.instance.FlowerNum}";
    }
}