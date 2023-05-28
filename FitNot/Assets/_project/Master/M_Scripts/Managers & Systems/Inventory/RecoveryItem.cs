using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;

namespace AyaOmar
{
    public class RecoveryItem : MonoBehaviour
    {
        public Item recoveryItem;
        private Transform player;

        void Start()
        {
            //player = GameObject.FindGameObjectWithTag("Player").transform;
            player = GameManager.Instance.GetPlayerRef().transform;

        }
        public void Use()
        {
           // GameObject gameEffect = Instantiate(recoveryItem.itemUseEffect, player.position, Quaternion.identity);
            player.GetComponent<HealthManager>().Heal(recoveryItem.healingAmount);
            AudioManager.Instance.Play2DSfx("rivo");
            Destroy(gameObject);
          //  Destroy(gameEffect, recoveryItem.timeToDestroy);
        }
    }
}
