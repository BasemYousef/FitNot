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
    


}
