using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] private Sound[] sounds;

    private AudioSource _audioSource;
    private GameInfo GameInfo => GameManager.Instance.Data.GameInfo;

#if UNITY_WEBGL
    public void Init()
    {
        Debug.Log($"---Audio Manager Started---");
        _audioSource = GetComponent<AudioSource>();
    }
#elif UNITY_EDITOR
    private void OnValidate()
    {
        Debug.Log($"Audio Manager Started");
        _audioSource = GetComponent<AudioSource>();
    }
#endif

    //private void Start() => SetAudioVolume();

    public void OnButtonPlay()
    {
        SetSound(SoundType.ButtonPlay);
    }

    public void OnButtonChange()
    {
        SetSound(SoundType.ButtonNext);
    }

    public void SetSound(SoundType soundType)
    {
        Debug.Log($"{soundType}, Sounds Length {sounds.Length}");
        foreach (var clip in sounds)
            if (clip.type == soundType)
                _audioSource.PlayOneShot(clip.clip);
    }

    public void SetSound(AudioClip audioClip)
    {
        Debug.Log($"{audioClip}, Sounds Length {sounds.Length}");
        _audioSource.PlayOneShot(audioClip);
    }

    public void Silence(string mixerGroup, float value)
    {
        float volume = Mathf.Log10(value) * 20;

        if (value < .01f)
            volume = -80;

        mixer.SetFloat(mixerGroup, volume);

        Debug.Log($"---------- {mixerGroup} Volume {volume} -------------");
    }
    
    private void SetAudioVolume()
    {
        Silence("MasterVolume", GameInfo.AudioVolume / 100);
        Silence("MusicVolume", GameInfo.MusicVolume / 100);
        Silence("SFXVolume", GameInfo.SFXVolume / 100);
    }

    public void AudioOff(bool value)
    {
        if (value)
            mixer.SetFloat("MasterVolume", -80);
        else
            Silence("MasterVolume", GameInfo.AudioVolume / 100);
    }
}

[Serializable]
public class Sound
{
    public SoundType type;
    public AudioClip clip;
}

public enum SoundType
{
    ButtonPlay,
    ButtonNext,
    ButtonCancel
}