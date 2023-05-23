using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class IdleState : StateMachineBehaviour
    {
        [SerializeField] public EnemyData enemy;
        
        float timer;
        string PATROLLING_PARAM = "isPatrolling";
        string CHASING_PARAM = "isChasing";
        string PLAYER_TAG = "Player";

        private Transform player;
    
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            timer = 0;
            //player = GameObject.FindGameObjectWithTag(PLAYER_TAG).transform;
            player = GameManager.Instance.GetPlayerRef().transform;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            timer += Time.deltaTime;
            if (timer > enemy.waitingTimeToStartPatrolling)
            {
                animator.SetBool(PATROLLING_PARAM, true);
            }
            float distance = Vector3.Distance(player.position, animator.transform.position);
            if (distance < enemy.chaseRange)
            {
                animator.SetBool(CHASING_PARAM, true);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

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
