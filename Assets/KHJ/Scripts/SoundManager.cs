using System.Collections;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource BgmAudio
    {
        get => _bgmAudio;
    }

    public AudioSource SfxAudio
    {
        get => _sfxAudio;
    }

    [SerializeField] AudioSource _bgmAudio = null;

    [SerializeField] AudioSource _sfxAudio = null;

    [SerializeField] AudioClip[] _bgmClips = null;

    [SerializeField] AudioClip[] _sfxClips = null;



    protected override void Awake()
    {
        base.Awake();

        _bgmAudio.loop = true;
        _bgmAudio.playOnAwake = false;
    }

    public void PlayBgm(Bgm bgm)
    {
        _bgmAudio.clip = _bgmClips[(int)bgm];
        _bgmAudio.Play();
    }

    public void PlaySfx(Sfx sfx)
    {
        _sfxAudio.PlayOneShot(_sfxClips[(int)sfx]);
    }

    public void PlaySfx(Sfx sfx, float volume)
    {
        _sfxAudio.PlayOneShot(_sfxClips[(int)sfx], volume);
    }
}

public enum Bgm
{
    MAIN_MENU,IN_GAME
}

public enum Sfx
{
    GAMEOVER, COUNTDOWN, BUTTON, DAMAGED, FLOWER_GET, USE_POWER, USE_BOMB, USE_MAGNET, USE_POTION, HORNET_RUSH, HORNET_BUZZ
}