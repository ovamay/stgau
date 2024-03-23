using UniRx;
using UnityEngine;

public class MoneyPresenter : MonoBehaviour
{
    public static System.Action OnCoinCollected;

    public ReactiveProperty<int> Money = new ReactiveProperty<int>(0);

    private int Cash => GameManager.Instance.Data.GameInfo.Money.Value;

    private int _score = 0;

    public void OnEnable() => OnCoinCollected += AddMoney;

    public void OnDisable() => OnCoinCollected -= AddMoney;

    private void AddMoney()
    {
        Money.Value++;
        _score++;

        if (_score > GameManager.Instance.Data.GameInfo.Score.Value)
            GameManager.Instance.Data.GameInfo.Score.Value = _score;

        GameManager.Instance.Data.GameInfo.Money.Value++;
        GameManager.Instance.Data.Save();
    }

    public bool TryBuy(ProductData productData)
    {
        if (productData.Price <= Cash)
        {
            GameManager.Instance.Data.GameInfo.Money.Value -= productData.Price;
            GameManager.Instance.Data.GameInfo.Bought.Add(productData);
            GameManager.Instance.Data.Save();

            return true;
        }
        else
        {
            Debug.LogError("No Money");
            return false;
        }
    }
}