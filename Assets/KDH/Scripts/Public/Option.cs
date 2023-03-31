using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public static Option instance;

    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        bgmSlider.onValueChanged.AddListener(delegate { RefreshBgmVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { RefreshSfxVolume(); });
    }

    void RefreshBgmVolume()
    {
    }

    void RefreshSfxVolume()
    {
    }
}