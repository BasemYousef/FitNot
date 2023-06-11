using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Youssef
{
    public class FootStepsAnimEvent : MonoBehaviour
    {
        [SerializeField] AudioSource footstep;

        public void PlayFootSteps()
        {
            footstep.pitch = Random.Range(0.5f, 6f);
            footstep.Play();
        }
    }
}
