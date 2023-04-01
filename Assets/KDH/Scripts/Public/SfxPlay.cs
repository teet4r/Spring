using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlay : MonoBehaviour
{
    [SerializeField] Sfx sfx;
    private void Start()
    {
        SoundManager.Instance.PlaySfx(sfx);
    }
}