using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class SpawnSpecialItem : MonoBehaviour
    {
        [SerializeField] private List<GameObject> FoodCar = new List<GameObject>();
        
        [SerializeField] private GameObject itemPrefab;
       
        void Start()
        {
            SpawnItem();
        }
        private Transform GetRandomPosition(List<GameObject> objects)
        {
            if (objects.Count == 0)
            {
                Debug.LogError("The list is empty.");
            }

            int randomIndex = Random.Range(0, objects.Count);
            GameObject randomObject = objects[randomIndex];

            return randomObject.transform;
        }
        private void SpawnItem()
        {
            Transform _item = GetRandomPosition(FoodCar);
            Instantiate(itemPrefab, _item.position, itemPrefab.transform.rotation);
            
        }
        
    }
}
