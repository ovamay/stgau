using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterData", menuName = "Character Data", order = 51)]
public class CharacterData : ProductData
{
    [SerializeField] private Sprite _spriteOutline;

    public Sprite SpriteOutline { get => _spriteOutline; }
}
