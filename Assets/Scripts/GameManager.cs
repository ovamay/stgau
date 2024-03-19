using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PauseManager PauseManager;
    public AudioManager AudioManager;
    public Data Data;


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            Instance = this;
        }

        Data.Init();
        AudioManager.Init();
        PauseManager.Init(AudioManager);

        Debug.Log("------------Application started-----------");
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
        AudioManager.AudioOff(!hasFocus);
    }

    private void OnApplicationPause(bool isPaused)
    {
        PauseManager.Pause(isPaused);
        AudioManager.AudioOff(isPaused);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        PauseManager.Pause(false);
        SceneManager.LoadScene(0);
        Debug.Log("Quit game");
    }
}
