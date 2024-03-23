using UnityEngine;
using UnityEngine.UI;

public class StorePresenter : MonoBehaviour
{
    [Header("Changed")]
    [SerializeField] private Image _backgroundSprite;
    [SerializeField] private Image _characterSprite;

    [SerializeField] private MoneyPresenter _moneyPresenter;

    private GameInfo _gameInfo => GameManager.Instance.Data.GameInfo;

    private void Start()
    {
        if (_gameInfo.LocationData.Sprite != null)
            _backgroundSprite.sprite = _gameInfo.LocationData.Sprite;

        if (_gameInfo.CharacterData != null)
            _characterSprite.sprite = _gameInfo.CharacterData.SpriteOutline;
    }

    public bool OnProductClick(ProductData productData)
    {
        foreach (var product in _gameInfo.Bought)
            if (product.Id == productData.Id)
            {
                ChangeProduct(productData);
                return false;
            }

        if (_moneyPresenter.TryBuy(productData))
        {
            ChangeProduct(productData);
            return true;
        }

        return false;
    }

    private void ChangeProduct(ProductData productData)
    {
        if (productData.Product == Product.Character)
        {
            GameManager.Instance.Data.GameInfo.CharacterData = (CharacterData)productData;
            _characterSprite.sprite = _gameInfo.CharacterData.SpriteOutline;
        }
        else
        {
            GameManager.Instance.Data.GameInfo.LocationData = (LocationData)productData;
            _backgroundSprite.sprite = _gameInfo.LocationData.Sprite;
        }

        GameManager.Instance.Data.Save();
    }
}
