using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class SpawnSpecialItem : MonoBehaviour
    {
        [SerializeField] private List<Transform> SpawnItemPositions = new List<Transform>();
        
        [SerializeField] private GameObject itemPrefab;
       
        void Start()
        {
            SpawnItem();
        }
        private Transform GetRandomPosition(List<Transform> objects)
        {
            if (objects.Count == 0)
            {
                Debug.LogError("The list is empty.");
            }

            int randomIndex = Random.Range(0, objects.Count);
            Transform randomObject = objects[randomIndex];

            return randomObject.transform;
        }
        private void SpawnItem()
        {
            Transform _item = GetRandomPosition(SpawnItemPositions);
            Instantiate(itemPrefab, _item.position, itemPrefab.transform.rotation);
            
        }
        
    }
}
