using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private Transform _gun;
    [SerializeField] public GameObject _bullet;
    [SerializeField] public GameObject _player;
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] public float _bulletSpeed;
    public PlayerInput MPI;
    private InputAction shoot;

    private bool canShoot;
    [SerializeField] private float _maxShotCooldown;
    [SerializeField] private float _shotCooldown;

    private bool shooting;

    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        MPI = GetComponent<PlayerInput>();

        //Grabs all the player's inputs
        shoot = MPI.currentActionMap.FindAction("Shoot");
        MPI.currentActionMap.Enable();
        shoot.started += ShootStart;
        shoot.canceled += ShootCancel;
    }

    public void OnDestroy()
    {
        //Remove control when OnDestroy activates
        if (shoot != null)
        {
            shoot.started -= ShootStart;
            shoot.canceled -= ShootCancel;
        }
    }

    private void ShootStart(InputAction.CallbackContext obj)
    {
        shooting = true;
        //if (canShoot)
        //{
        //    canShoot = false;
        //    ShootBullet();
        //}
    }
    private void ShootCancel(InputAction.CallbackContext obj)
    {
        shooting = false;
    }

    void ShootBullet()
    {
        GameObject BulletInstance = Instantiate(_bullet, _bulletSpawn.position, _bulletSpawn.rotation);
        BulletInstance.GetComponent<Rigidbody2D>().AddForce(BulletInstance.transform.right * _bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting)
        {
            if (canShoot)
            {
                canShoot = false;
                ShootBullet();
            }
        }
        if (canShoot == false)
        {
            _shotCooldown -= Time.deltaTime;
            if (_shotCooldown <= 0)
            {
                canShoot = true;
                _shotCooldown = _maxShotCooldown;
            }
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)_gun.position;
        FaceMouse();
        if (mousePos.x < _player.transform.position.x)
        {
            _gun.transform.localScale = new Vector2(1, -1);
        }
        else if (mousePos.x > _player.transform.position.x)
        {
            _gun.transform.localScale = new Vector2(1, 1);
        }
    }

    void FaceMouse()
    {
        _gun.transform.right = direction;
    }
}
