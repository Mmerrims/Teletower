using UnityEngine;

public class HeadCheck : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _gameManager.HeadCrush = true;
        }

        if (collision.gameObject.tag == "Win")
        {
            _gameManager.Win = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _gameManager.HeadCrush = false;
        }
    }
}
