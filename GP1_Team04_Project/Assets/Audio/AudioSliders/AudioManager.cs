
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;

    [SerializeField] AudioSource buttonPressSource;
    [SerializeField] private AudioClip buttonPressClip;

    [SerializeField] AudioSource HPCollectSource;
    [SerializeField] private AudioClip HPCollectClip;

    [SerializeField] AudioSource hurtSoundSource;
    [SerializeField] private AudioClip hurtSoundClip;

    [SerializeField] AudioSource coinCollectSource;
    [SerializeField] private AudioClip coinCollectClip;

    public const string MUSIC_KEY = "MusicVolume";
    public const string SFX_KEY = "SFXVolume";

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadVolume();
    }

    void LoadVolume() //Volume saved in VolumeSettings
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);

        mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);

    }

    public void CoinCollectSFX()
    {
        AudioClip coinclip = coinCollectClip;
        coinCollectSource.PlayOneShot(coinclip);
    }

    public void HPCollectSFX()
    {
        AudioClip HPclip = HPCollectClip;
        HPCollectSource.PlayOneShot(HPclip);
    }

    public void HurtSoundSFX()
    {
        AudioClip Hurtclip = hurtSoundClip;
        hurtSoundSource.PlayOneShot(Hurtclip);
    }
    public void ButtonPress()
    {
        AudioClip buttonClip = buttonPressClip;
        buttonPressSource.PlayOneShot(buttonClip);
    }

}
