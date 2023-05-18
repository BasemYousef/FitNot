using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  [CreateAssetMenu(fileName ="EnemyWaveController",menuName ="CreateWaveController/EnemySpawner")]
    public class SpawnerManager : ScriptableObject
    {
        public float waveCooldown ;
        public float spawnRadius ;
        public int startingEnemyCount ;
        public int enemyIncreasePerWave ;
        public float difficultyMultiplier ;
    }

