using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y);
    }
}
