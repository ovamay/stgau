using TMPro;
using UniRx;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _moneyText;

    [Header("Presenters")]
    [SerializeField] private MoneyPresenter _money;

    private void Start()
    {
        _money.Money
            .Select(money => string.Format("������� �����: {0}", money))
            .Subscribe(text => _moneyText.text = text);
    }
}
