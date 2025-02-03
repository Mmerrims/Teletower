using UnityEngine;

public class ParticleWiggle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rB2D;
    [SerializeField] private SpriteRenderer _sR;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _delay;
    [SerializeField] private float _transdownValue;

    private void Start()
    {
        Wiggle();
    }

    private void Wiggle()
    {
        _rB2D.velocity = new Vector2(Random.Range(-_maxSpeed, _maxSpeed),
            Random.Range(-_maxSpeed, _maxSpeed));

        Invoke("Wiggle", _delay);
    }

    private void FixedUpdate()
    {
        Color col = _sR.color;
        col.a -= _transdownValue;
        _sR.color = col;
    }
}
