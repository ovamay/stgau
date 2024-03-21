using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event Action OnStartGame;

    public PauseManager PauseManager;
    public AudioManager AudioManager;
    public Data Data;

    public void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            Instance = this;
        }

        Init();
    }

    private void Init()
    {
        Data.Init();
        AudioManager.Init();
        PauseManager.Init(AudioManager);
    }

    public void CursorLocked(bool value)
    {
        if (value)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;

        Cursor.visible = !value;
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        PauseManager.Pause(!hasFocus);
        AudioManager.Silence(!hasFocus);
    }

    private void OnApplicationPause(bool isPaused)
    {
        PauseManager.Pause(isPaused);
        AudioManager.Silence(isPaused);
    }

    public void StartGame() => SceneManager.LoadScene(1);

    public void QuitGame()
    {
        PauseManager.Pause(false);
        SceneManager.LoadScene(0);
    }
}
