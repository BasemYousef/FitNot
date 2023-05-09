using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AyaOmar
{
    public class PatrolState : StateMachineBehaviour
    {
        public EnemyData enemy;
        float timer;
        string PATROLLING_PARAM = "isPatrolling";
        string CHASING_PARAM = "isChasing";

        List<Transform> wayPoints = new List<Transform>();
        NavMeshAgent agent;

        Transform player;

        int index = 0;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            agent = animator.GetComponent<NavMeshAgent>();
            agent.speed = enemy.walkSpeed;
            timer = 0;
            //GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
            foreach(Transform t in WayPoints.Instance.GetWayPoints())
            {
                wayPoints.Add(t);
            }
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
            
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);

            }
            timer += Time.deltaTime;
            if (timer > enemy.waitingTimeToStartChasing)
            {
                animator.SetBool(PATROLLING_PARAM, false);
            }

            float distance = Vector3.Distance(player.position, animator.transform.position);
            if (distance < enemy.chaseRange)
            {
                animator.SetBool(CHASING_PARAM, true);
            }
            index++;
            if (index == 10)
            {
                index = 0;
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            agent.SetDestination(agent.transform.position);
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
