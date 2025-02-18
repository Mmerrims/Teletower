using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;


public class PlayerMovement : MonoBehaviour
{
    public PlayerInput MPI;
    private InputAction move;
    private InputAction restart;
    private InputAction quit;
    private InputAction jump;
    
    public float PlayerSpeed;
    public bool PlayerShouldBeMoving;
    public bool CanMove;
    public Rigidbody2D PlayerRB;
    [SerializeField] private float moveDirection;
    [SerializeField] private float inputHorizontal;
    public bool InAir;
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    [SerializeField] private Transform _self;
    [SerializeField] private bool _moving;
    private bool playerJump;
    public float JumpForce;
    public bool PerformLaunch;
    public int Colliding;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _velocityX;
    [SerializeField] private float _velocityY;
    [SerializeField] private float _currentDirection;
    [SerializeField] private Collider2D _collider;
   // [SerializeField] private CheckpointManager _checkpointManager;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public AudioManager audioManager;
    public GameObject audioManagerObject;

    private void Awake()
    {
        audioManagerObject = GameObject.Find("Audio Manager");
        if (audioManagerObject != null)
        {
            audioManager = audioManagerObject.GetComponent<AudioManager>();
        }

        _moving = false;
        PlayerRB = GetComponent<Rigidbody2D>();
        MPI = GetComponent<PlayerInput>();
        //Grabs all the player's inputs
        move = MPI.currentActionMap.FindAction("Move");
        restart = MPI.currentActionMap.FindAction("Restart");
        quit = MPI.currentActionMap.FindAction("Quit");
        jump = MPI.currentActionMap.FindAction("Jump");


        MPI.currentActionMap.Enable();
        jump.started += Handle_JumpAction;
        jump.canceled += Handle_JumpActionCanceled;
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
        jump.started -= Handle_JumpAction;
        jump.canceled -= Handle_JumpActionCanceled;
        restart.started -= Restart;
        quit.started -= Quit;
    }

    private void Handle_JumpAction(InputAction.CallbackContext obj)
    {
        //if (_parrying == false)
        //{
        // AudioSource.PlayClipAtPoint(Jumping, transform.position, 100);
            if (CanMove == true)
            {
                //Can only be active if dash isn't occuring
                //if (DashActive == false)


                //Checks if the player is touching the ground
                if (coyoteTimeCounter > 0f)
                /// if (IsColliding == true)
                {
                    //Makes the player jump command activate
                    playerJump = true;
                    //Allows the PerformLaunch Command to be allowed.
                    PerformLaunch = true;
                //Makes it so the double jump doesn't activate
                //DoubleJump = false;
                audioManager.Jump();
                }
                else
                {

                    //Makes is so the player can't jump, but they are able to double jump
                    playerJump = false;
                    PerformLaunch = true;
                    //if (CanDoubleJump == true)
                    //{
                    //    DoubleJump = true;
                    //    //Animator.SetBool("DoubleJump", true);
                    //}



                }
                if (playerJump == true)
                {
                    PlayerShouldBeMoving = true;
                }
                //print("Handled Jump Started");
            }
            //}
        



    }

    private void Handle_JumpActionCanceled(InputAction.CallbackContext context)
    {

            if (PlayerRB.velocity.y > 0f)
            {
                PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, PlayerRB.velocity.y * 0.5f);
            }
        
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
            audioManager.Move();
        }
                
    }
    private void Handle_MoveCanceled(InputAction.CallbackContext obj)
    {//Can only be active if dash isn't occuring
        _moving = false;
        PlayerShouldBeMoving = false;
        audioManager.MoveStop();
    }


    public void FixedUpdate()
    {


        if (coyoteTimeCounter > 0f)
        {
            //Checks if the player is colliding with something, and if so turns off InAir and makes sure the double jump doesn't occur
            //DoubleJump = false;
            InAir = false;

            //Animator.SetBool("InAir", false);

            //Animator.SetBool("OnGround", true);

        }

        if (CanMove == false)
        {
            Destroy(gameObject);
        }

        if (PlayerShouldBeMoving == true && CanMove == true)
        {
                //print("PlayerRB Should Be Moving");
                //Makes the player able to move, and turns on the moving animation   
                PlayerRB.velocity = new Vector2(PlayerSpeed * moveDirection, PlayerRB.velocity.y);
                _animator.SetBool("Walking", true);
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


        if (CanMove == true && PerformLaunch == true && playerJump == true)
        {
            //CoyoteTimer = 0;
            //IsColliding = false;

            if (transform.parent != null)
            {
                PlayerRB.velocity = new Vector2(transform.parent.GetComponent<Rigidbody2D>().velocity.x, JumpForce + transform.parent.GetComponent<Rigidbody2D>().velocity.y);
                coyoteTimeCounter = 0;
            }
            else
            {
                PlayerRB.velocity = new Vector2(0, JumpForce);
                coyoteTimeCounter = 0;
            }
            //print("PlayerRB should be jumpin");


            //Launches the player upwards

            //Turns off the player jump
            playerJump = false;
            PerformLaunch = false;
            //Turns on the jumping animation
            //Animator.SetBool("IsMoving", true);
            //Animator.SetBool("OnGround", false);
            //Animator.SetBool("InAir", true);
            //Animator.SetBool("DoubleJump", false);
            //Animator.SetBool("Dash", false);

            InAir = true;
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

        if (Colliding >= 1)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")//Checks if the player is touching the ground
        {
                print("Touch Grass");

                InAir = false;
                // CanDoubleJump = false;
                //JumpIndicator.gameObject.SetActive(false);
            Colliding++;
            audioManager.JumpLand();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {//Makes the game realize the player is not touching the ground
            //print("Dont Touch Grass");
            InAir = true;
            // CoyoteTime = true;
            // IsColliding = false;
            Colliding--;
            //CanDoubleJump = true;
            print("Left Grass");
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