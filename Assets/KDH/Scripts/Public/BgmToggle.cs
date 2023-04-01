using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmToggle : MonoBehaviour
{
    [SerializeField] Image image;

    private void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(delegate { ToggleBGM(); });
    }

    void ToggleBGM()
    {

    }
}