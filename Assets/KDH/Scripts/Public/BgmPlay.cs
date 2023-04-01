using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmPlay : MonoBehaviour
{
    [SerializeField] Bgm bgm;

    private void Start()
    {
        SoundManager.Instance.PlayBgm(bgm);
    }
}