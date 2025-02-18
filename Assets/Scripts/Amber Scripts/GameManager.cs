using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _gunCharges;

    //[SerializeField] private TMP_Text _scoreText;
    //private float score;
    [SerializeField] private TMP_Text _endScreenScoreText;
    [SerializeField] private TMP_Text _winScreenScoreText;
    //[SerializeField] private TMP_Text _maxScoreText;
    //private float maxScore;
    [SerializeField] private ShootScript _shootScript;
    private bool playing;
    //private static GameManager instance;
    public bool HeadCrush;
    public bool GroundCrush;
    public bool Death;
    public bool Win;
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private GameObject _winScreen;

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _spawners;
    //[SerializeField] private GameObject BallChargedObject;
    //[SerializeField] private Animator _scrollAnimator;
    public AudioManager audioManager;
    public GameObject audioManagerObject;
    private bool endState;

    private void Start()
    {
       // score = 0;
        //UpdateText();
        playing = true;

        audioManagerObject = GameObject.Find("Audio Manager");
        
        if (audioManagerObject != null)
        {
            audioManager = audioManagerObject.GetComponent<AudioManager>();
        }
        audioManager.GameTheme();
        endState = false;
    }

    //public void UpdateText()
    //{
    //    _gunCharges.text = ("Charges: " + _shootScript.CurrentShots);
    //}

    public void FixedUpdate()
    {
        //if (_shootScript.CanShoot == true)
        //{
        //    BallChargedObject.SetActive(true);

        //} else
        //{
        //    BallChargedObject.SetActive(false);
        //}

        if (HeadCrush == true && GroundCrush == true || Death == true)
        {
            if (endState == false)
            {
                playing = false;
                _deathScreen.SetActive(true);
                if (_playerMovement != null)
                {
                    _playerMovement.CanMove = false;
                }
                _shootScript.EndShooting = true;
                audioManager.BobDeath();
                audioManager.BobDeathMusic();
                audioManager.GameThemeEnd();
                endState = true;
            }
            //_scrollAnimator.SetBool("StopLose", true);
        }

        if (playing == false)
        {
            _spawners.SetActive(false);
        }

        if (Win == true)
        {
            if (endState == false)
            {
                playing = false;
                _winScreen.SetActive(true);
                if (_playerMovement != null)
                {
                    _playerMovement.CanMove = false;
                }
                _shootScript.EndShooting = true;
                audioManager.Win();
                audioManager.GameThemeEnd();
                endState = true; 
            }
           // _scrollAnimator.SetBool("StopWin", true);
        }

        //if (playing)
       //{
            //score += 1;
       // }
        //if (score > maxScore)
        //{
        //    maxScore = score;
        //}

        //_scoreText.text = ("Score: " + score);
        //_endScreenScoreText.text = ("Final Score: " + score);
        //_winScreenScoreText.text = ("Final Score: " + score);
        //_maxScoreText.text = ("High Score: " + maxScore);
    }

    //private void Awake()
    //{
    //    score = 0;
    //    if (instance == null)
    //    {
    //        // Makes the instance 
    //        instance = this;
    //        // Makes it so this object does not get destroyed on load
    //        DontDestroyOnLoad(instance);
    //    }
    //    else
    //    {
    //        // Makes it so there aren't multiple instances of the Game Manager
    //        Destroy(gameObject);
    //    }
    //}
}
