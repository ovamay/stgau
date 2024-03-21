using UnityEngine;
using UnityEngine.UI;

public class UIStore : MonoBehaviour
{
    [Header("Product Data")]
    [SerializeField] private ProductData _productData;
    [SerializeField] private GameObject _grassPanel;

    [Header("Presenter")]
    [SerializeField] private StorePresenter _storePresenter;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(() =>
        {
            if (_storePresenter.OnProductClick(_productData))
                _grassPanel.SetActive(false); 
        });
    }


}