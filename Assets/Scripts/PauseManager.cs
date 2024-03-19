using UnityEngine;

public class PauseManager : MonoBehaviour
{
    AudioManager _audioManager;

    public void Init(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    public void Pause(bool value)
    {
        if (value)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
