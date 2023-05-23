using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Add Mummy Data",menuName = "Add Mummy Data/MummyInfo")]
public class EnemyData : ScriptableObject
{
    public float walkSpeed;
    public float runSpeed;
    public float maxHealth;
    public float currentHealth;
    public float damageValue;
    public float attackRange;
    public float chaseRange;
    public int waitingTimeToStartChasing;
    public int waitingTimeToStartPatrolling;
    private SpawnerManager spawnerManager;

    public float ModifiedDamageValue
    {
        get { return damageValue * spawnerManager.difficultyDamageMultiplier; }
    }

    public float ModifiedMaxHealth
    {
        get { return maxHealth * spawnerManager.difficultyHealthMultiplier; }
    }
}
