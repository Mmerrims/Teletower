using UnityEngine;

public class AimingScript : MonoBehaviour
{
    [SerializeField] private Transform _gun;
    [SerializeField] public GameObject _player;

    private Vector2 direction;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)_gun.position;
        FaceMouse();
    }

    void FaceMouse()
    {
        _gun.transform.right = direction;
    }
}
