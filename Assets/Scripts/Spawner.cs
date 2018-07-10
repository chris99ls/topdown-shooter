using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Wave[] waves;
    public Enemy enemy;

    Wave currentWave;
    int currentWaveNumber;
    int enemiesRemainingAlive;

    int enemiesRemaingToSpawn;
    float nextSpawnTime;

    void Start()
    {
        NextWave();
    }

    void Update()
    {
        if(enemiesRemaingToSpawn>0 && Time.time > nextSpawnTime)
        {
            enemiesRemaingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
            spawnedEnemy.OnDeath += OnEnemyDeath;
        }
    }

    void OnEnemyDeath()
    {
        enemiesRemainingAlive--;

        if (enemiesRemainingAlive == 0)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        currentWaveNumber++;
        print("Waves: " + currentWaveNumber);
        if (currentWaveNumber - 1 < waves.Length)
        {



            currentWave = waves[currentWaveNumber - 1];

            enemiesRemaingToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemaingToSpawn;
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    } 

}
