using System;
using UniRx;
using UnityEngine;

public class MoneyPresenter : MonoBehaviour
{
    public static System.Action OnCoinCollected;
    
    public ReactiveProperty<int> Money = new ReactiveProperty<int>(0);

    private bool _isBought = false;
    private int _id;
    private int _score = 0;

    private int Cash => GameManager.Instance.Data.GameInfo.Money;

    public void OnEnable()
    {
        OnCoinCollected += AddMoney;
    }

    public void OnDisable()
    {
        OnCoinCollected -= AddMoney;
    }

    private void AddMoney()
    {
        Money.Value++;
        _score++;

        GameManager.Instance.Data.GameInfo.Money++;
        GameManager.Instance.Data.Save();
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
        }
        else Debug.Log("No money, rabotai");
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
