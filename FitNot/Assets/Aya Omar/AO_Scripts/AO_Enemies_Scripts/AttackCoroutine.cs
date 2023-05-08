using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class AttackCoroutine : MonoBehaviour
    {
        private Transform player;
        private EnemyData enemy;
        private MUMMY_TYPES mummyType;
        private Coroutine coroutine;

        public void StartAttackCoroutine(Transform player, EnemyData enemy, MUMMY_TYPES mummyType)
        {
            this.player = player;
            this.enemy = enemy;
            this.mummyType = mummyType;

            // Start the coroutine
            coroutine = StartCoroutine(AttackLoop());
        }

        public void StopAttackCoroutine()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }

        private System.Collections.IEnumerator AttackLoop()
        {
            while (true)
            {
                float distance = Vector3.Distance(player.position, transform.position);
                Debug.Log("distance"+ distance + " enemy range" + enemy.attackRange);
                if (distance < enemy.attackRange)
                {
                    Debug.Log("...............");

                    // Attack the player
                    if (mummyType == MUMMY_TYPES.Spitter_Mummy)
                    {
                        Debug.Log("Spitter..");
                        SpitterMummy.Instance.Attack();
                    }
                    else if (mummyType == MUMMY_TYPES.Melee_Mummy)
                    {
                        MeleeMummy.Instance.Attack();
                    }
                }

                yield return new WaitForSeconds(1.3f); // Adjust the interval as needed
            }
        }
    }
}

