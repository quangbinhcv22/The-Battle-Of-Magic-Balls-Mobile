using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnRange = 2f;
    private int enemyCount;
    public int waveNumber = 1;

    private int sumLevelEnemy;
    private int sumLevelEnemySpawned;

    private PlayerBall playerBall;
    private EnemyBall[] enemyBalls;
    private EnemyBallPool enemyBallPool;

    private void Awake()
    {
        enemyBallPool = GetComponent<EnemyBallPool>();

        playerBall = FindObjectOfType<PlayerBall>();
    }

    private void Start()
    {
        Invoke("SpawnNewEnemyWaveIfNoEnemy", 0.5f);
    }

    public void SpawnNewEnemyWaveIfNoEnemy()
    {
        if (enemyBallPool.GetCountEnemyActive() == 0)
        {
            playerBall.SetLevel(waveNumber);

            SpawnEnemyWave(waveNumber);
            waveNumber++;
        }
    }

    void SpawnEnemyWave(int enemyToSpawn)
    {
        sumLevelEnemy = waveNumber;
        sumLevelEnemySpawned = 0;

        while (sumLevelEnemySpawned < sumLevelEnemy)
        {
            int randomeLevel = RandomLevel();
            sumLevelEnemySpawned += randomeLevel;

            GameObject enemySpawnFromPool = enemyBallPool.GetRandomEnemy(randomeLevel);
            enemySpawnFromPool.transform.position = GenerateSpawnPosition();
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = 10f;

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        return spawnPos;
    }

    int RandomLevel()
    {
        return Random.Range(1, waveNumber);
    }


}
