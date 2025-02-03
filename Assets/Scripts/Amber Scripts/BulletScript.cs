using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private Transform _thisTransform;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _player = GameObject.Find("Player");
            _player.transform.position = _thisTransform.transform.position;
            Destroy(gameObject);
        }
    }
}
