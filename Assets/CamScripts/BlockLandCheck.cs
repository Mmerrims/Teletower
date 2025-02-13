using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLandCheck : MonoBehaviour
{
    private GameObject _camera;
    private bool _firstHit;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.Find("Main Camera");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_firstHit && (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("BlockFreeze")))
        {
            _camera.GetComponent<Animator>().Play("CameraShake");
            _firstHit = false;
        }
    }
}
