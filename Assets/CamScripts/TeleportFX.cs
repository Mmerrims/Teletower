using UnityEngine;

public class TeleportFX : MonoBehaviour
{

    [SerializeField] private GameObject _pX;
    [SerializeField] private GameObject _pY;
    [SerializeField] private GameObject _pZ;
    [SerializeField] private Transform _playerTransform;

    public void TeleportFXSpawn()
    {
        Instantiate(_pX, _playerTransform.position, Quaternion.identity);
        Instantiate(_pX, _playerTransform.position, Quaternion.identity);
        Instantiate(_pY, _playerTransform.position, Quaternion.identity);
        Instantiate(_pY, _playerTransform.position, Quaternion.identity);
        Instantiate(_pZ, _playerTransform.position, Quaternion.identity);
        Instantiate(_pZ, _playerTransform.position, Quaternion.identity);
    }
}
