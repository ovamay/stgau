using System;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public GameInfo GameInfo;

    public void Init() => Load();

    public void Load()
    {
        GameInfo gameInfo;
        gameInfo = JsonUtility.FromJson<GameInfo>(PlayerPrefs.GetString("GameData"));

        if (gameInfo != null)
            GameInfo = gameInfo;
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(GameInfo);
        PlayerPrefs.SetString("GameData", json);
    }
}

[Serializable]
public class GameInfo
{
    public float AudioVolume = 100f;
    public float MusicVolume = 100f;
    public float SFXVolume = 100f;

    public int Money = 0;
    public int Score = 0;
    public Sprite BackgroundSprite;
    public Sprite CharacterSprite;

    public List<int> Bought = new List<int>();
}
