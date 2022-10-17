
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;

    [SerializeField] AudioSource coinCollectSource;
    [SerializeField] List<AudioClip> coinCollectClip = new List<AudioClip>();

    [SerializeField] AudioSource HPCollectSource;
    [SerializeField] List<AudioClip> HPCollectClip = new List<AudioClip>();

    [SerializeField] AudioSource hurtSoundSource;
    [SerializeField] List<AudioClip> hurtSoundClip = new List<AudioClip>();

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
        AudioClip coinclip = coinCollectClip[Random.Range(0, coinCollectClip.Count)];
        coinCollectSource.PlayOneShot(coinclip);
    }

    public void HPCollectSFX()
    {
        AudioClip HPclip = HPCollectClip[Random.Range(0, HPCollectClip.Count)];
        HPCollectSource.PlayOneShot(HPclip);
    }

    public void HurtSoundSFX()
    {
        AudioClip Hurtclip = hurtSoundClip[Random.Range(0, hurtSoundClip.Count)];
        hurtSoundSource.PlayOneShot(Hurtclip);
    }

}
