using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPref;

    public void OnEnable() => MoneyPresenter.OnCoinCollected += SpawnMoney;

    public void OnDisable() => MoneyPresenter.OnCoinCollected -= SpawnMoney;

    private void Start() => SpawnMoney();

    private void SpawnMoney()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-4.5f, 4.5f), 0);
        Instantiate(_spawnPref, spawnPoint, Quaternion.identity);
    }
}
