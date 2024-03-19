using System;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    [SerializeField] private Sound[] _sounds;

    private AudioSource _audioSource;
    private GameInfo GameInfo => GameManager.Instance.Data.GameInfo;

    public void Init()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnValidate()
    {
        _audioSource = GetComponent<AudioSource>();
    }

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
        Debug.Log($"{soundType}, Sounds Length {_sounds.Length}");
        foreach (var clip in _sounds)
            if (clip.type == soundType)
                _audioSource.PlayOneShot(clip.clip);
    }

    public void SetSound(AudioClip audioClip)
    {
        Debug.Log($"{audioClip}, Sounds Length {_sounds.Length}");
        _audioSource.PlayOneShot(audioClip);
    }

    public void Silence(bool value)
    {
        if (value)
            AudioListener.pause = true;
        else
            AudioListener.pause = false;
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