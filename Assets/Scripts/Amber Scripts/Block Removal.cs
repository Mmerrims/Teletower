using System.Collections;
using UnityEngine;

public class BlockRemoval : MonoBehaviour
{
    [SerializeField] private float _deathTime;
    [SerializeField] private Rigidbody2D _rigidbody;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BlockRemove")
        {
            print("RemoveStart");
            StartCoroutine(Remove());
        }
        if (collision.gameObject.tag == "BlockFreeze")
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BlockRemove")
        {
            print("RemoveStart");
            StartCoroutine(Remove());
        }
        if (collision.gameObject.tag == "BlockFreeze")
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(_deathTime);
        Destroy(gameObject);
    }

}
