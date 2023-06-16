using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class SpawnSpecialItem : MonoBehaviour
    {
        [SerializeField] private List<Transform> SpawnItemPositions = new List<Transform>();
        
        [SerializeField] private GameObject itemPrefab;
        private float time = 0;
        private float timeToSpawnItem = 15;
        void Start()
        {
            SpawnItem();
        }
        private void Update()
        {
            time += Time.deltaTime;
            if (time >= timeToSpawnItem)
            {
                SpawnItem();
                time = 0;
            }
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
            GameObject item = Instantiate(itemPrefab, _item.position, itemPrefab.transform.rotation);
            Destroy(item, timeToSpawnItem);
        }
        
    }
}
