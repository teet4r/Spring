using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SfxToggle : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Sprite muteSprite;
    [SerializeField] Sprite nonMuteSprite;
    Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate { ToggleSFX(); });
    }

    void ToggleSFX()
    {
        SoundManager.Instance.PlaySfx(Sfx.BUTTON);
        SoundManager.Instance.MuteSfx(toggle.isOn);
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