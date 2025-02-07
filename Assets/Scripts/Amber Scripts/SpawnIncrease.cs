using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIncrease : MonoBehaviour
{
    [SerializeField] private Debris _debris;

    public void Increase()
    {
        _debris.EnemySpawnCooldown -= .3f;
    }
}
