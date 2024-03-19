using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip _crashSound;
    [SerializeField] private GameObject _deathPanel;

    private float _speed = 5;
    private Vector3 _dir = new Vector3(-1, 0, 0);
    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        GameManager.Instance.OnStartGame += StartGame;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnStartGame -= StartGame;
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() => _dir = Vector3.zero;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (moveX > 0)
        {
            _spriteRenderer.flipX = true;
            _dir = new Vector3(1, 0, 0);
        }
        else if (moveX < 0)
        {
            _spriteRenderer.flipX = false;
            _dir = new Vector3(-1, 0, 0);
        }

        if (moveY > 0)
        {
            _dir = new Vector3(0, 1, 0);
        }
        else if (moveY < 0)
        {
            _dir = new Vector3(0, -1, 0);
        }

        transform.position += _dir * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("deathZone"))
        {
            _deathPanel.SetActive(true);
            GameManager.Instance.AudioManager.SetSound(_crashSound);
            enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coin coin;

        if (collision.TryGetComponent(out coin))
        {
            coin.Collected();
            _speed += .15f;
        }
    }

    private void StartGame()
    {
        enabled = true;
        _dir = new Vector3(-1, 0, 0);
        transform.position = Vector3.zero;
        _spriteRenderer.flipX = false;
        _speed = 5;
    }
}
