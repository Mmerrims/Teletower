using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class PlayerMovement : MonoBehaviour
{
    public PlayerInput MPI;
    private InputAction move;
    private InputAction restart;
    private InputAction quit;
    
    public float PlayerSpeed;
    public bool PlayerShouldBeMoving;
    public bool CanMove;
    public Rigidbody2D PlayerRB;
    [SerializeField] private float moveDirection;
    [SerializeField] private float inputHorizontal;
    public bool InAir;
    [SerializeField] private Transform _self;
    [SerializeField] private bool _moving;

   
    [SerializeField] private Animator _animator;

    [SerializeField] private float _velocityX;
    [SerializeField] private float _velocityY;
    [SerializeField] private float _currentDirection;
    [SerializeField] private Collider2D _collider;
   // [SerializeField] private CheckpointManager _checkpointManager;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _moving = false;
        PlayerRB = GetComponent<Rigidbody2D>();
        MPI = GetComponent<PlayerInput>();
        //Grabs all the player's inputs
        move = MPI.currentActionMap.FindAction("Move");
        restart = MPI.currentActionMap.FindAction("Restart");
        quit = MPI.currentActionMap.FindAction("Quit");
        

        MPI.currentActionMap.Enable();
        move.started += Handle_MoveStarted;
        move.canceled += Handle_MoveCanceled;
        restart.started += Restart;
        quit.started += Quit;
    }

    public void OnDisable()
    {
        MPI.currentActionMap.Disable();
        move.started -= Handle_MoveStarted;
        move.canceled -= Handle_MoveCanceled;
        restart.started -= Restart;
        quit.started -= Quit;
    }

    //private void Handle_ToMenuPerformed(InputAction.CallbackContext context)
    //{
    //    SceneManager.LoadScene("IntroCutscene");
    //}

    private void Handle_MoveStarted(InputAction.CallbackContext obj)
    {
        if (CanMove)
        {
            // Can only be active if dash isn't occuring
                //Turns on the movement command
                PlayerShouldBeMoving = true;
            _moving = true;
        }
                
    }
    private void Handle_MoveCanceled(InputAction.CallbackContext obj)
    {//Can only be active if dash isn't occuring
            _moving = false;
            PlayerShouldBeMoving = false;
    }


    public void FixedUpdate()
    {
        if (PlayerShouldBeMoving == true && CanMove == true)
        {
                //print("PlayerRB Should Be Moving");
                //Makes the player able to move, and turns on the moving animation   
                PlayerRB.velocity = new Vector2(PlayerSpeed * moveDirection, PlayerRB.velocity.y);
                _animator.SetBool("Walking", true);
        }

    }
    // Update is called once per frame
    public void Update()
    {
        if (_velocityY < -1)
        {
            InAir = true;
                _animator.SetBool("Falling", true);
            

        }

        if (_velocityY >= -1)
        {
            InAir = false;
            _animator.SetBool("Falling", false);
            //_animator.SetBool("Jumping", false);
        }

        _velocityX = PlayerRB.velocity.x;
        _velocityY = PlayerRB.velocity.y;

        if (PlayerRB.velocity.y < -2 || _moving == false)
        {
            _animator.SetBool("Walking", false);
        }


        if (PlayerShouldBeMoving == true)
        {
            //Checks what direction the player should be moving(Horizontally)
            moveDirection = move.ReadValue<float>();
        }
        else if (PlayerShouldBeMoving == false)
        {
            PlayerRB.velocity = new Vector2(0, PlayerRB.velocity.y);
        }

        if (_velocityX > 0)
        {
            gameObject.transform.localScale = new Vector2(1, 1);
            _currentDirection = 1;
        }
        else if (_velocityX < 0)
        {
            gameObject.transform.localScale = new Vector2(-1, 1);
            _currentDirection = -1;
        }
    }

    public void Restart(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit(InputAction.CallbackContext obj)
    {
        Application.Quit();
        print("Quit");
    }
}