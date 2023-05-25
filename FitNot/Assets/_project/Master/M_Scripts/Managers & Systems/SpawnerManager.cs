using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  [CreateAssetMenu(fileName ="EnemyWaveController",menuName ="CreateWaveController/EnemySpawner")]
    public class SpawnerManager : ScriptableObject
    {
       [HideInInspector] public float difficultyDamageMultiplier = 1.0f;
       [HideInInspector] public float difficultyHealthMultiplier = 1.0f;
      
        public float spawnRadius ;
        public int startingEnemyCount = 0;
        public int enemyIncreasePerWave ;
        public float waveCooldown;
    }

