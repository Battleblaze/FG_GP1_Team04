using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource hoverboardSource;
    [SerializeField] AudioSource bmSource;

    [SerializeField] private AudioClip buttonPressClip;
    [SerializeField] private AudioClip HPCollectClip;
    [SerializeField] private AudioClip hurtSoundClip;
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
        SFXSource.PlayOneShot(coinclip);
    }

    public void HPCollectSFX()
    {
        AudioClip HPclip = HPCollectClip;
        SFXSource.PlayOneShot(HPclip);
    }

    public void HurtSoundSFX()
    {
        AudioClip Hurtclip = hurtSoundClip;
        SFXSource.PlayOneShot(Hurtclip);
    }
    public void ButtonPress()
    {
        AudioClip buttonClip = buttonPressClip;
        SFXSource.PlayOneShot(buttonClip);
        Debug.Log("ButtonPressed");
    }

    public void PauseAudio()
    {
        hoverboardSource.Pause();
    }

    public void UnPauseAudio()
    {
        hoverboardSource.UnPause();
    }
}