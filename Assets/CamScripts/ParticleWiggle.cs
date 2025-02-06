
using UnityEngine;

public class ParticleWiggle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rB2D;
    [SerializeField] private SpriteRenderer _sR;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _delay;
    [SerializeField] private float _transdownValue;

    /// <summary>
    /// Starting wiggle movement
    /// </summary>
    private void Start()
    {
        Wiggle();
    }

    /// <summary>
    /// Move in a random direction at a random speed, after a delay pick a new direction and speed
    /// </summary>
    private void Wiggle()
    {
        _rB2D.velocity = new Vector2(Random.Range(-_maxSpeed, _maxSpeed),
            Random.Range(-_maxSpeed, _maxSpeed));

        Invoke("Wiggle", _delay);
    }

    /// <summary>
    /// Every time fixed update calls, the opacity is reduced by _transdownValue, at 0% opacity destroy object
    /// </summary>
    private void FixedUpdate()
    {
        Color col = _sR.color;
        col.a -= _transdownValue;
        _sR.color = col;

        if (col.a == 0)
        {
            Destroy(gameObject);
        }
    }
}
