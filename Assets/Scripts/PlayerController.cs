using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float Speed { get => _speed; set { if (value > 5) _speed = value; } }
    private float _speed = 5;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private GameObject deathPanel;
    private Vector3 _dir = new Vector3(-1, 0, 0);
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        enabled = false;
        _dir = Vector3.zero;
    }

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
            deathPanel.SetActive(true);
            GameManager.Instance.AudioManager.SetSound(crashSound);
            enabled = false;
        }
    }

    public void StartGame()
    {
        enabled = true;
        _dir = new Vector3(-1, 0, 0);
        transform.position = Vector3.zero;
        _spriteRenderer.flipX = false;
        _speed = 5;
    }
}
