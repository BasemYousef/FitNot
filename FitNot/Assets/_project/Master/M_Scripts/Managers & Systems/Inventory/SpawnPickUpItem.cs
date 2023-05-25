using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class SpawnPickUpItem : MonoBehaviour
    {
        public GameObject itemPrefab;
       
        private Transform player;
        void Start()
        {
            player = GameManager.Instance.GetPlayerRef().transform;
        }
        public void SpawnDropedItem()
        {
            Vector3 playerPos = new Vector3(player.position.x, player.position.y + 1, player.position.z+4);
            Instantiate(itemPrefab, playerPos, Quaternion.identity);
        }
       
    }
}
