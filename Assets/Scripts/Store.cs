using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] private Image backgroundSprite;
    [SerializeField] private SpriteRenderer characterSprite;
        
    public void SelectBackground(Sprite sprite)
    {
        backgroundSprite.sprite = sprite;
        GameManager.Instance.Data.GameInfo.BackgroundSprite = sprite;
        GameManager.Instance.Data.Save();
    }
    public void SelectCharacter(Sprite sprite)
    {
        characterSprite.sprite = sprite;
        GameManager.Instance.Data.GameInfo.CharacterSprite = sprite;
        GameManager.Instance.Data.Save();
    }

    private void Start()
    {
        backgroundSprite.sprite = GameManager.Instance.Data.GameInfo.BackgroundSprite;
        characterSprite.sprite = GameManager.Instance.Data.GameInfo.CharacterSprite;
    }
}
