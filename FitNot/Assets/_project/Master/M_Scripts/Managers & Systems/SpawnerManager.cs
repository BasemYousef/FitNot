using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;


  [CreateAssetMenu(fileName ="EnemyWaveController",menuName ="CreateWaveController/EnemySpawner")]
    public class SpawnerManager : ScriptableObject
    {

        public float healthMultiplier = 1.0f;
        public float spawnRadius ;
        public int enemyIncreasePerWave = 1 ;
        public float waveCooldown;
    }

