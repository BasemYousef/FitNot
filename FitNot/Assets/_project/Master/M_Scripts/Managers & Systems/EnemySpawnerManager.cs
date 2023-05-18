using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    #region Serialized Private Variables
    [SerializeField] private GameObject[] enemyPrefabs; 
    [SerializeField] private Transform player;
    public SpawnerManager spawnerManager;
    #endregion

    #region Private Variables
    private int currentWave = 0; 
    private bool isSpawning = false;
    #endregion
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(spawnerManager.waveCooldown);
        while (true)
        {
            currentWave++;
            int enemyCount = spawnerManager.startingEnemyCount + (spawnerManager.enemyIncreasePerWave * (currentWave - 1));
            for (int i = 0; i < enemyCount; i++)
            {
                
                Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnerManager.spawnRadius;
                Vector3 spawnPosition = player.position + new Vector3(randomCircle.x, 0f, randomCircle.y);

               
                GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

               
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnerManager.waveCooldown);


            spawnerManager.difficultyMultiplier += 1;


            spawnerManager.waveCooldown *= 0.95f; // Decrease the cooldown by 5% each wave
        }
    }
}
