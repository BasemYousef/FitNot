using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
namespace AyaOmar
{
    public class ChaseState : StateMachineBehaviour
    {
        public EnemyData enemy;
        public MUMMY_TYPES mummyType;

        Transform player;
        NavMeshAgent agent;
        private AttackCoroutine attackCoroutine;

        string PATROLLING_PARAM = "isPatrolling";
        string CHASING_PARAM = "isChasing";
        string ATTACKING_PARAM = "isAttacking";

        private SpitterMummy spitterRef;

        //private float chaseRange = 15;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            player = GameManager.Instance.GetPlayerRef().transform;
            agent = animator.GetComponent<NavMeshAgent>();
            agent.speed = enemy.runSpeed;

            attackCoroutine = animator.GetComponent<AttackCoroutine>();
            if (attackCoroutine == null)
            {
                attackCoroutine = animator.gameObject.AddComponent<AttackCoroutine>();
            }

            // Start the coroutine to continuously check attack range
            attackCoroutine.StartAttackCoroutine(player, enemy, mummyType,animator);

        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            agent.SetDestination(player.position);
            spitterRef = animator.GetComponent<SpitterMummy>();
            float distance = Vector3.Distance(player.position, animator.transform.position);
            if (distance > enemy.chaseRange)
            {
                animator.SetBool(CHASING_PARAM, false);
            }
            //if (distance <= enemy.attackRange)
            //{
            //    //animator.SetBool(ATTACKING_PARAM, true);
            //    if (mummyType == MUMMY_TYPES.Spitter_Mummy)
            //    {
            //        if (spitterRef != null)
            //        {
            //            spitterRef.Attack();
            //        }
            //    }
            //}
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            agent.SetDestination(animator.transform.position);
            // Stop the attack coroutine when leaving the chase state
            
        }


        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }

}

