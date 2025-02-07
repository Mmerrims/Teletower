using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
   
        [SerializeField] public bool _canSpawn;
        private int enemySpawn;
        private int randomTarget;
        public int TotalEnemyTypes;
        public int TotalSpawnPoints;
        private Transform targetSpawnPoint;
        [SerializeField] private Transform[] enemySpawnPoint;
        [SerializeField] private GameObject[] enemyTypes;
        private GameObject targetEnemy;
        [SerializeField] private Transform _self;
        public float EnemySpawnCooldown;
    // Update is called once per frame

    private void Start()
    {
        EnemySpawnCooldown = 3;
    }

    void Update()
        {
            if (_canSpawn == true)
            {
                _canSpawn = false;
                StartCoroutine(SpawnCooldown());
                randomTarget = Random.Range(0, TotalSpawnPoints);
                targetSpawnPoint = enemySpawnPoint[randomTarget];
                enemySpawn = Random.Range(0, TotalEnemyTypes);
                targetEnemy = enemyTypes[enemySpawn];
                
                GameObject enemySpawning = Instantiate(targetEnemy, targetSpawnPoint.position, _self.rotation);
            }
        }

        private IEnumerator SpawnCooldown()
        {
            yield return new WaitForSeconds(EnemySpawnCooldown);
            _canSpawn = true;
        }
    }
