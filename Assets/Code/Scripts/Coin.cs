using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _coinSound;

    public void Collected()
    {
        MoneyPresenter.OnCoinCollected?.Invoke();
        GameManager.Instance.AudioManager.SetSound(_coinSound);
        Destroy(gameObject);
    }
}
