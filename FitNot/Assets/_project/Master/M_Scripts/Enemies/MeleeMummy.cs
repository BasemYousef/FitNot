using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;

namespace AyaOmar
{
    public class MeleeMummy : MonoBehaviour, IAttackable
    {
        private Animator animator;
        private string ATTACK_PARAM = "isAttacking";
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        public void Attack()
        {
            animator.SetBool(ATTACK_PARAM, true);
            AudioManager.Instance.Play2DPingPongSfx("whoosh");
        }
    }
}
