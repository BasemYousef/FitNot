using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;

public class EnemySpawnerManager : MonoBehaviour
{
    #region Serialized Private Variables
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform player;
    [HideInInspector] public SpawnerManager spawnerManager;
    [SerializeField] private float playerRadius = 15f;
    #endregion

    #region Private Variables
    private List<GameObject> activeEnemies = new List<GameObject>();
    private int currentWave = 0;
    private int wavesSinceLastIncrement = 0;
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
            wavesSinceLastIncrement++;
            if (currentWave % 3 == 0)
            {
                int enemyCount = spawnerManager.startingEnemyCount + (spawnerManager.enemyIncreasePerThreeWaves * ((currentWave / 3) - 1));

                for (int i = 0; i < enemyCount; i++)
                {

                    Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnerManager.spawnRadius;
                    Vector3 spawnPosition = player.position + new Vector3(randomCircle.x, 0f, randomCircle.y);


                    GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

                    GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                    activeEnemies.Add(spawnedEnemy);
                }
            }
            if (wavesSinceLastIncrement >= 10)
            {
                wavesSinceLastIncrement = 0;

                // Increment the difficulty factors
                spawnerManager.difficultyHealthMultiplier += 0.1f;
                spawnerManager.difficultyDamageMultiplier += 0.1f;
            }
            yield return new WaitForSeconds(spawnerManager.waveCooldown);

            spawnerManager.waveCooldown *= 0.99f; // Decrease the cooldown by 1% each wave
        }
    }
    private void Update()
    {
        // Disable enemies that are out of range of the player
        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            GameObject enemy = activeEnemies[i];
            if (Vector3.Distance(enemy.transform.position, player.position) > playerRadius)
            {
              
                DisableEnemy(enemy);
            }
            else if (!enemy.activeSelf && Vector3.Distance(enemy.transform.position, player.position) <= playerRadius)
            {
               
                EnableEnemy(enemy);
            }
        }
    }

    private void DisableEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
       
    }

    private void EnableEnemy(GameObject enemy)
    {
        enemy.SetActive(true);
      
    }

}