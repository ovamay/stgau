using TMPro;
using UniRx;
using UnityEngine;

public class MoneyScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
        GameManager.Instance.Data.GameInfo.Money
            .Select(money => string.Format("{0}", money))
            .Subscribe(text => _moneyText.text = text);

        GameManager.Instance.Data.GameInfo.Score
            .Select(score => string.Format("{0}", score))
            .Subscribe(text => _scoreText.text = text);
    }
}
