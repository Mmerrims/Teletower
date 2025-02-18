using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _gameManager.GroundCrush = true;
        }
        if (collision.gameObject.tag == "BlockRemove")
        {
            _gameManager.Death = true;
        } 
        if (collision.gameObject.tag == "Death")
        {
            _gameManager.Death = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _gameManager.GroundCrush = false;
        }
    }

}
