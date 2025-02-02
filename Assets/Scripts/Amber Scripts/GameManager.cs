using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _gunCharges;
    [SerializeField] private TMP_Text _scoreText;
    private float score;
    [SerializeField] private TMP_Text _endScreenScoreText;
    //[SerializeField] private TMP_Text _maxScoreText;
    //private float maxScore;
    [SerializeField] private ShootScript _shootScript;
    private bool playing;
    //private static GameManager instance;
    public bool HeadCrush;
    public bool GroundCrush;
    [SerializeField] private GameObject _deathScreen;

    [SerializeField] private PlayerMovement _playerMovement;

    private void Start()
    {
        score = 0;
        UpdateText();
        playing = true;
    }

    public void UpdateText()
    {
        _gunCharges.text = ("Charges: " + _shootScript.CurrentShots);
    }

    public void FixedUpdate()
    {
        if (HeadCrush == true && GroundCrush == true)
        {
            playing = false;
            _deathScreen.SetActive(true);
            _playerMovement.CanMove = false;
            _shootScript.EndShooting = true;
        }

        if (playing)
        {
            score += 1;
        }
        //if (score > maxScore)
        //{
        //    maxScore = score;
        //}

        _scoreText.text = ("Score: " + score);
        _endScreenScoreText.text = ("Final Score: " + score);
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
