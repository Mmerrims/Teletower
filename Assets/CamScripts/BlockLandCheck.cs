using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLandCheck : MonoBehaviour
{
    private GameObject _camera;
    private bool _firstHit = true;
    public AudioManager audioManager;
    public GameObject audioManagerObject;


    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.Find("Main Camera");
        audioManagerObject = GameObject.Find("Audio Manager");
        if (audioManagerObject != null)
        {
            audioManager = audioManagerObject.GetComponent<AudioManager>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_firstHit && (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("BlockFreeze")))
        {
            _camera.GetComponent<Animator>().Play("CameraShake");
            audioManager.BlockPlace();
            _firstHit = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_firstHit && (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("BlockFreeze")))
        {
            _camera.GetComponent<Animator>().Play("CameraShake");
            audioManager.BlockPlace();
            _firstHit = false;

        }
    }
}
