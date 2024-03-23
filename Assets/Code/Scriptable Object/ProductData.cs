using UnityEngine;

public class ProductData : ScriptableObject
{
    [SerializeField] private int _id; 
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Product _product;
    [SerializeField] private int _price;

    public int Id { get => _id; }
    public Sprite Sprite { get => _sprite; }
    public Product Product { get => _product; }
    public int Price { get => _price; }
}
