using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlayButtonSound);
    }

    void PlayButtonSound()
    {
        SoundManager.Instance.PlaySfx(Sfx.BUTTON);
    }
}