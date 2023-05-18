using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;

namespace AyaOmar
{
    public class RecoveryItem : MonoBehaviour
    {
        public GameObject effect;
        private Transform player;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

        }
        public void Use()
        {
            GameObject gameEffect = Instantiate(effect, player.position, Quaternion.identity);
            player.GetComponent<HealthManager>().Heal(20f);
            Destroy(gameObject);
            Destroy(gameEffect, 5);
        }
    }
}
