using UniRx;
using UnityEngine;

public class MoneyPresenter : MonoBehaviour
{
    public static System.Action OnCoinCollected;

    public ReactiveProperty<int> Money = new ReactiveProperty<int>(0);

    private int _score = 0;

    private int Cash => GameManager.Instance.Data.GameInfo.Money;

    public void OnEnable() => OnCoinCollected += AddMoney;

    public void OnDisable() => OnCoinCollected -= AddMoney;

    private void AddMoney()
    {
        Money.Value++;
        _score++;

        GameManager.Instance.Data.GameInfo.Money++;
        GameManager.Instance.Data.Save();
    }

    public bool TryBuy(ProductData productData)
    {
        if (productData.Price <= Cash)
        {
            GameManager.Instance.Data.GameInfo.Money -= productData.Price;
            GameManager.Instance.Data.GameInfo.Bought.Add(productData.Id);
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