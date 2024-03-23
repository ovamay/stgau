using UnityEngine;
using UnityEngine.UI;

public class UIButtonStore : MonoBehaviour
{
    [Header("Product Data")]
    [SerializeField] private ProductData _productData;
    [SerializeField] private GameObject _grassPanel;

    [Header("Presenter")]
    [SerializeField] private StorePresenter _storePresenter;

    private Button _button;

    private GameInfo _gameInfo => GameManager.Instance.Data.GameInfo;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        foreach (var product in _gameInfo.Bought)
            if (product.Id == _productData.Id && _grassPanel != null)
                _grassPanel.SetActive(false);

        _button.onClick.AddListener(() =>
        {
            if (_storePresenter.OnProductClick(_productData) && _grassPanel != null)
                _grassPanel.SetActive(false); 
        });
    }


}