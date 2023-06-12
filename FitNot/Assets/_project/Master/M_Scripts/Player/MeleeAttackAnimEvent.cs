using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Youssef
{
    public class MeleeAttackAnimEvent : MonoBehaviour
    {
        [SerializeField] private Collider attackCollider;
        [SerializeField] private GameObject attackEffect;
        [SerializeField] private float timeStopDuration = 0.2f; 

        public void StartAttack()
        {
            Debug.Log("StartAttack() called");
            StartCoroutine(PerformTimeStop());
            attackCollider.enabled = true;
            attackEffect.SetActive(true);
        }

        private IEnumerator PerformTimeStop()
        {
            
            float initialTimeScale = Time.timeScale;

            Time.timeScale = 0f;

            yield return new WaitForSecondsRealtime(timeStopDuration);

            Time.timeScale = initialTimeScale;
        }

        public void StopAttack()
        {
            if (attackCollider != null)
            {
                attackCollider.enabled = false;
                attackEffect.SetActive(false);
            }
        }
    }
}
