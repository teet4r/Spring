using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public static Option instance;

    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] GameObject optionWindow;

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
        SoundManager.Instance.BgmAudio.volume = bgmSlider.value;
    }

    void RefreshSfxVolume()
    {
        SoundManager.Instance.SfxAudio.volume = sfxSlider.value;
    }

    public void OpenOptionWindow()
    {
        optionWindow.SetActive(true);
    }

    public void CloseOptionWindow()
    {
        optionWindow.SetActive(false);
    }
}