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

    public bool CanShoot;
    [SerializeField] private float _maxShotCooldown;
    [SerializeField] private float _shotCooldown;

    [SerializeField] private int _maxShots;
    [SerializeField] private int _currentShots;
    [SerializeField] private float _maxReloadCooldown;
    [SerializeField] private float _reloadCooldown;

    [SerializeField] private GameManager _gameManager;

    private bool shooting;
    public bool EndShooting;

    private Vector2 direction;

    [SerializeField] private bool _teleport;
    [SerializeField] private GameObject _currentBullet;
    [SerializeField] private Animator _ballAnimator;
    public int CurrentShots { get => _currentShots; set => _currentShots = value; }

    [SerializeField] private Rigidbody2D _playerRigidbody;

    [SerializeField] private TeleportFX _tFX;
    // Start is called before the first frame update

    public AudioManager audioManager;
    public GameObject audioManagerObject;
    void Start()
    {
        CanShoot = true;
        MPI = GetComponent<PlayerInput>();

        //Grabs all the player's inputs
        shoot = MPI.currentActionMap.FindAction("Shoot");
        MPI.currentActionMap.Enable();
        shoot.started += ShootStart;
        shoot.canceled += ShootCancel;

        audioManagerObject = GameObject.Find("Audio Manager");
        if (audioManagerObject != null)
        {
            audioManager = audioManagerObject.GetComponent<AudioManager>();
        }
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
        audioManager.BallThrow();
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentBullet == null)
        {
            //print("No bullet");
            _teleport = false;
        }
        else
        {
            _currentBullet = GameObject.Find("bullet(Clone)");
            _teleport = true;
        }

        if (CanShoot == true)
        {
            _ballAnimator.SetBool("Activate", true);
            _ballAnimator.SetBool("Deactivate", false);
        } else
        {
            _ballAnimator.SetBool("Activate", false);
            _ballAnimator.SetBool("Deactivate", true);
        }
        

        if (shooting && EndShooting == false)
        {
            if (CanShoot)
            {
                CanShoot = false;
                

                if (_teleport == false && _currentShots > 0)
                {
                    CanShoot = false;
                    ShootBullet();
                    _currentBullet = GameObject.Find("bullet(Clone)");
                    _shotCooldown -= .9f;
                    _currentShots -= 1;
                    print("Shot bullet");
                }
                if (_teleport == true)
                {
                    _currentBullet = GameObject.Find("bullet(Clone)");
                    if(_player != null)
                    {
                        _player.transform.position = _currentBullet.transform.position;
                        _playerRigidbody.velocity = new Vector2(0, 0);
                        _tFX.TeleportFXSpawn();
                        audioManager.Teleport();
                    }
                    Destroy(_currentBullet);
                    print("Teleported");
                }
                
                //_gameManager.UpdateText();
            }
        }
        if (CanShoot == false)
        {
            _shotCooldown -= Time.deltaTime;
            if (_shotCooldown <= 0)
            {
                CanShoot = true;
                _ballAnimator.Play("BallActivate");
                _shotCooldown = _maxShotCooldown;
                audioManager.BallRefill();
            }
        }
        if (_currentShots < _maxShots)
        {
            _reloadCooldown -= Time.deltaTime;
            if (_reloadCooldown <= 0)
            {
                _reloadCooldown = _maxReloadCooldown;
                _currentShots += 1;
                //_gameManager.UpdateText();
            }

        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)_gun.position;
        FaceMouse();
        if (_player != null)
        {
            if (mousePos.x < _player.transform.position.x)
            {
                _gun.transform.localScale = new Vector2(1, -1);
            }
            else if (mousePos.x > _player.transform.position.x)
            {
                _gun.transform.localScale = new Vector2(1, 1);
            }
        }
    }

    void FaceMouse()
    {
        _gun.transform.right = direction;
    }
}
