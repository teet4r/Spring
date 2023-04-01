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
    [SerializeField] GameObject optionButton;
    [SerializeField] GameObject mainMenuButtonGroup;
    [SerializeField] GameObject inGameButtonGroup;

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

    public void RefreshOption()
    {
        if (SceneManager.GetActiveScene().name == "InGame")
        {
            optionButton.SetActive(false);
            mainMenuButtonGroup.SetActive(false);
            inGameButtonGroup.SetActive(true);
        }
        else
        {
            optionButton.SetActive(true);
            mainMenuButtonGroup.SetActive(true);
            inGameButtonGroup.SetActive(false);
        }
    }

    private void Start()
    {
        bgmSlider.onValueChanged.AddListener(delegate { RefreshBgmVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { RefreshSfxVolume(); });
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "InGame")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OptionWindowActivate();
            }
        }
    }

    void OptionWindowActivate()
    {
        optionWindow.SetActive(!optionWindow.activeSelf);
    }

    void RefreshBgmVolume()
    {
        SoundManager.Instance.BgmAudio.volume = bgmSlider.value;
    }

    void RefreshSfxVolume()
    {
        SoundManager.Instance.SfxAudio.volume = sfxSlider.value;
    }
}