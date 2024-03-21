using UnityEngine;

[CreateAssetMenu(fileName = "New ProductData", menuName = "Product Data", order = 51)]
public class ProductData : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private Sprite _spriteOutline;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Product _product;
    [SerializeField] private int _price;

    public int Id { get => _id; }
    public Sprite SpriteOutline { get => _spriteOutline; }
    public Sprite Sprite { get => _sprite; }
    public Product Product { get => _product; }
    public int Price { get => _price; }
}
