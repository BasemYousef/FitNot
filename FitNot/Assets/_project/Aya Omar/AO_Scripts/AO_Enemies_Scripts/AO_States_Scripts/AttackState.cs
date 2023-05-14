using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class AttackState : StateMachineBehaviour
    {
        public EnemyData enemy;
        Transform player;
        //private float attackRange = 3;

        private AttackCoroutine attackCoroutine;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            attackCoroutine = animator.GetComponent<AttackCoroutine>();
            if (attackCoroutine == null)
            {
                attackCoroutine = animator.gameObject.AddComponent<AttackCoroutine>();
            }
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Vector3 targetPlayer = new Vector3(player.transform.position.x, animator.transform.position.y, player.transform.position.z);
            animator.transform.LookAt(targetPlayer);
            float distance = Vector3.Distance(player.position, animator.transform.position);
            if (distance > enemy.attackRange)
            {
                animator.SetBool("isAttacking", false);
                
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (attackCoroutine != null)
            {
                attackCoroutine.StopAttackCoroutine();
            }
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