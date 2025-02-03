using System.Collections;
using UnityEngine;

public class BlockRemoval : MonoBehaviour
{
    [SerializeField] private float _deathTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BlockRemove")
        {
            print("RemoveStart");
            StartCoroutine(Remove());
        }
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(_deathTime);
        Destroy(gameObject);
    }

}
