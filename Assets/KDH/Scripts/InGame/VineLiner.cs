using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineLiner : MonoBehaviour
{
    [SerializeField] int vineNum;
    [SerializeField] GameObject[] vines;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform tmpTr = transform.GetChild(i);
            for (int j = 0; j < vineNum; j++)
            {
                Instantiate(vines[Random.Range(0, vines.Length)], tmpTr);
            }
        }
    }
}