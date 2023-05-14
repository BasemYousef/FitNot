using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Destroy(gameObject);
            Destroy(gameEffect, 5);
        }
    }
}
