using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private Transform _thisTransform;

    public AudioManager audioManager;
    public GameObject audioManagerObject;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _playerRigidbody = _player.GetComponent<Rigidbody2D>();

        audioManagerObject = GameObject.Find("Audio Manager");
        if (audioManagerObject != null)
        {
            audioManager = audioManagerObject.GetComponent<AudioManager>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "BlockRemove")
        {
            if (_player != null)
            {
                _player.transform.position = _thisTransform.transform.position;
                _playerRigidbody.velocity = new Vector2(0, 0);
                _player.GetComponent<TeleportFX>().TeleportFXSpawn();
                audioManager.Teleport();
            }
            Destroy(gameObject);
        }
    }
}
