using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace AyaOmar
{
    public class SpawnPickUpItem : MonoBehaviour
    {
        public GameObject itemPrefab;

        [SerializeField] private GameObject itemDescription;
        [SerializeField] private Item item;
        [SerializeField] private TMP_Text txtDescription;
       
        private Transform player;
        void Start()
        {
            player = GameManager.Instance.GetPlayerRef().transform;
            txtDescription.text = item.description;
        }
        private void Update()
        {
            itemDescription.transform.Rotate(0, 0, 0);
        }
        public void SpawnDropedItem()
        {
            Vector3 playerPos = new Vector3(player.position.x, player.position.y + 1, player.position.z+4);
            Instantiate(itemPrefab, playerPos, Quaternion.identity);
        }
        private void OnMouseOver()
        {
            itemDescription.SetActive(true);
        }
        private void OnMouseExit()
        {
            itemDescription.SetActive(false);

        }

    }
}
