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
        if (_gameInfo.BackgroundSprite != null)
            _backgroundSprite.sprite = _gameInfo.BackgroundSprite;

        if (_gameInfo.CharacterSprite != null)
            _characterSprite.sprite = _gameInfo.CharacterSprite;
    }

    public bool OnProductClick(ProductData productData)
    {
        foreach (var id in _gameInfo.Bought)
            if (id == productData.Id)
                ChangeProduct(productData);
            else
            {
                if (_moneyPresenter.TryBuy(productData))
                {
                    ChangeProduct(productData);
                    return true;
                }
            }

        return false;
    }

    private void ChangeProduct(ProductData productData)
    {
        if (productData.Product == Product.Character)
        {
            GameManager.Instance.Data.GameInfo.CharacterSprite = productData.SpriteOutline;
            _characterSprite.sprite = productData.Sprite;
        }
        else
        {
            GameManager.Instance.Data.GameInfo.BackgroundSprite = productData.Sprite;
            _characterSprite.sprite = productData.Sprite;
        }

        GameManager.Instance.Data.Save();
    }
}
