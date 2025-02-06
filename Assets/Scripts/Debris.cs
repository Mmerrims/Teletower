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
        private float enemySpawnCooldown;
    // Update is called once per frame
        
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
            enemySpawnCooldown = Random.Range(1f, 3f);
            yield return new WaitForSeconds(enemySpawnCooldown);
            _canSpawn = true;
        }
    }
