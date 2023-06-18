using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Youssef
{
    public class CharactersAnimationEvents : MonoBehaviour
    {
        [SerializeField] private Collider attackCollider;
        [SerializeField] private Collider unarmedCollider;
        [SerializeField] private GameObject attackEffect;
        [SerializeField] AudioSource footstep;
        [SerializeField] private float timeStopDuration = 0.2f;

        public void StartAttack()
        {
            // Enable the attack collider
            attackCollider.enabled = true;
            attackEffect.SetActive(true);
        }

        public void StopAttack()
        {
            if (attackCollider != null)
            {
                // Disable the attack collider
                attackCollider.enabled = false;
                attackEffect.SetActive(false);
            }
        }
        public void StartUnarmedAttack()
        {
            // Enable the attack collider
            unarmedCollider.enabled = true;
            attackEffect.SetActive(true);

        }
        public void StopUnarmedAttack()
        {
            // Disable the attack collider
            unarmedCollider.enabled = false;
            attackEffect.SetActive(false);

        }
        public void PlayMeleeWhooshSFX()
        {
            AudioManager.Instance.Play2DPingPongSfx("whoosh");
        }
        public void PlayFootSteps()
        {
            footstep.pitch = Random.Range(0.5f, 6f);
            footstep.Play();
        }
        public void PlayDashSFX()
        {
            AudioManager.Instance.Play2DSfx("dash");
        }
    }
}
