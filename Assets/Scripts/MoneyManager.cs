using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private int _money = 0;
    [SerializeField] private TextMeshProUGUI moneyGameText;
    [SerializeField] private TextMeshProUGUI moneyStoreText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AudioClip coinSound;
    public GameObject moneyPref;
    PlayerController _playerController;
    private bool _isBought = false;
    private int _id;
    private int _score = 0;
    private int Cash => GameManager.Instance.Data.GameInfo.Money;  
    

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        moneyStoreText.text = $"Валюта: {Cash}";
        scoreText.text = $"Рекорд: {GameManager.Instance.Data.GameInfo.Score}";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        _money++;
        _score++;
        GameManager.Instance.Data.GameInfo.Money++;
        GameManager.Instance.Data.Save();
        moneyGameText.text = $"Собрано монет: {_money}";
        moneyStoreText.text = $"Валюта: {Cash}";
        SpawnMoney();
        _playerController.Speed += 0.15f;
        GameManager.Instance.AudioManager.SetSound(coinSound);
    }

    void SpawnMoney()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-4.5f, 4.5f), 0);

        GameObject point = Instantiate(moneyPref, spawnPoint, Quaternion.identity);
    }

    public void Buy(int price)
    {
        if (_isBought)
        {
            price = 0;
            _isBought = false;
        }

        if (price <= Cash)
        {
            GameManager.Instance.Data.GameInfo.Money -= price;
            GameManager.Instance.Data.GameInfo.Bought.Add(_id);
            GameManager.Instance.Data.Save();
            moneyStoreText.text = $"Валюта: {Cash}";
            
        }
        else Debug.Log("No money rabotai");
    }

    public void StartGame()
    {
        _money = 0;
        moneyGameText.text = $"Собрано монет: {_money}";        
    }

    public void ScoreUpdate()
    {
        if (_score > GameManager.Instance.Data.GameInfo.Score)
        {
            GameManager.Instance.Data.GameInfo.Score = _score;
            GameManager.Instance.Data.Save();
        }
        scoreText.text = $"Рекорд: {GameManager.Instance.Data.GameInfo.Score}";
        _score = 0;
    }
    public void SetPrice(int id)
    {
        _id = id;
        foreach (var item in GameManager.Instance.Data.GameInfo.Bought)
        {
            if (id == item)
            {
                _isBought = true;                                
            }
        }
    }
}
