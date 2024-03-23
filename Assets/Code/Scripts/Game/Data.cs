using System;
using System.Collections.Generic;
using UniRx;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class Data : MonoBehaviour
{
    [Header("Initialization Data")]
    [SerializeField] private CharacterData _characterData;
    [SerializeField] private LocationData _locationData;

    public GameInfo GameInfo;

    public void Init() => Load();

    public void Load()
    {
        GameInfo gameInfo;
        gameInfo = JsonUtility.FromJson<GameInfo>(PlayerPrefs.GetString("GameData"));

        if (gameInfo != null)
            GameInfo = gameInfo;
        else
        {
            GameInfo = new GameInfo();
            GameInfo.Bought.Add(_characterData);
            GameInfo.Bought.Add(_locationData);
            GameInfo.CharacterData = _characterData;
            GameInfo.LocationData = _locationData;
        }
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
    public ReactiveProperty<int> Money = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> Score = new ReactiveProperty<int>(0);
    public CharacterData CharacterData;
    public LocationData LocationData;

    public List<ProductData> Bought = new List<ProductData>();
}
