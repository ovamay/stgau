using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private Image _background;

    [Header("Presenters")]
    [SerializeField] private MoneyPresenter _money;

    private void Start()
    {
        if (GameManager.Instance.Data.GameInfo.LocationData != null)
        _background.sprite = GameManager.Instance.Data.GameInfo.LocationData.Sprite;

        _money.Money
            .Select(money => string.Format("Собрано монет: {0}", money))
            .Subscribe(text => _moneyText.text = text);
    }
}
