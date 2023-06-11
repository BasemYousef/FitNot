using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Youssef;

public class EnemySpawnerManager : MonoBehaviour
{
    #region Serialized Private Variables
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform player;
    [SerializeField] private SpawnerManager spawnerManager;
    [SerializeField] private float playerRadius = 15f;
    [SerializeField] private int maxEnemyCount = 15;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float healthMultiplier = 1.1f;
    [SerializeField] private EnemyData[] enemyDataArray;
    [SerializeField] private GameObject spawnEffect;
    #endregion

    #region Private Variables
    private List<GameObject> activeEnemies = new List<GameObject>();
    private int currentWave = 0;
    private int currentDay = 0;
    private float previousHealthMultiplier = 1f;
    #endregion

    private void Start()
    {
        currentDay = DayTracker.Instance.Day;
        previousHealthMultiplier = healthMultiplier;

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(spawnerManager.waveCooldown);
        while (true)
        {
            currentWave++;

            int enemyCount = (currentDay * spawnerManager.enemyIncreasePerWave);

            for (int i = 0; i < enemyCount; i++)
            {
                int index = Random.Range(0, enemyPrefabs.Length);
                if (activeEnemies.Count >= maxEnemyCount) break;

                Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnerManager.spawnRadius;
                Vector3 spawnPosition = player.position + new Vector3(randomCircle.x, 0f, randomCircle.y);

                GameObject enemyPrefab = enemyPrefabs[index];
                EnemyData enemyData = enemyDataArray[index];
                GameObject spawnedEffect = Instantiate(spawnEffect, spawnPosition, Quaternion.identity);
                spawnedEffect.layer = enemyLayer;
                yield return new WaitForSeconds(2f);
                GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                spawnedEnemy.layer = enemyLayer;
                HealthManager enemyHealthManager = spawnedEnemy.GetComponent<HealthManager>();
                enemyHealthManager.SetMaxHealth(enemyData.maxHealth * GetHealthMultiplier()) ;
                activeEnemies.Add(spawnedEnemy);
                yield return new WaitForSeconds(3f);
                Destroy(spawnedEffect);
                Debug.Log(spawnedEnemy.name);
            }

            yield return new WaitForSeconds(spawnerManager.waveCooldown);
        }
    }
    
    private void Update()
    {
        int currentDay = DayTracker.Instance.Day;

        if (currentDay % 10 == 0 && currentDay > 0 && healthMultiplier != previousHealthMultiplier)
        {
            healthMultiplier = GetHealthMultiplier();
            previousHealthMultiplier = healthMultiplier;

          
            foreach (GameObject enemy in activeEnemies)
            {
                HealthManager enemyHealthManager = enemy.GetComponent<HealthManager>();
               
            }
        }
    }

    private float GetHealthMultiplier()
    {
        int currentDay = DayTracker.Instance.Day;
        int multiplierInterval = 10;
        float multiplierValue = 1.1f;

        int multiplierCount = Mathf.FloorToInt((currentDay - 1) / multiplierInterval);
        return Mathf.Pow(multiplierValue, multiplierCount);
    }
}
