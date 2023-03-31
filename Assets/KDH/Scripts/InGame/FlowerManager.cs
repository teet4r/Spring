using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    public static FlowerManager instance;

    [SerializeField] int flowerNum = 0;

    public int FlowerNum { get { return flowerNum; } }

    private void Awake()
    {
        instance = this;
    }

    public void AcquireFlower()
    {
        flowerNum++;
    }
}