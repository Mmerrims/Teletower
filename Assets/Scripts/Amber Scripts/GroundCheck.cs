using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "BlockRemove")
        {
            _gameManager.GroundCrush = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "BlockRemove")
        {
            _gameManager.GroundCrush = false;
        }
    }
}
