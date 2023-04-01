using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmToggle : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Sprite muteSprite;
    [SerializeField] Sprite nonMuteSprite;
    Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate { ToggleBGM(); });
    }

    void ToggleBGM()
    {
        SoundManager.Instance.PlaySfx(Sfx.BUTTON);
        SoundManager.Instance.MuteBgm(toggle.isOn);
        if (toggle.isOn)
        {
            image.sprite = muteSprite;
        }
        else
        {
            image.sprite = nonMuteSprite;
        }
    }
}