using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _gunCharges;
    [SerializeField] private ShootScript _shootScript;

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        _gunCharges.text = ("Charges: " + _shootScript.CurrentShots);
    }
}
