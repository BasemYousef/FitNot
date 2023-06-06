using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootSystem : MonoBehaviour
{
    public List<LootItem> lootItems;
    public float destroyDelay = 10f;
    private GameObject instantiatedItem;
    private Coroutine destroyTimerCoroutine;

    public void DestroyBox()
    {
        Debug.Log("method called ");
        if (lootItems.Count > 0)
        {
            LootItem selectedLootItem = GetRandomLootItem();

            if (selectedLootItem != null && selectedLootItem.itemPrefab != null)
            {
                Debug.Log("Instantiating loot item: " + selectedLootItem.itemPrefab.name);

                Vector3 spawnPosition = transform.position;
                spawnPosition.y = 0.5f;

                GameObject lootItemObject = Instantiate(selectedLootItem.itemPrefab, spawnPosition, Quaternion.identity);
                instantiatedItem = lootItemObject;

                
            }
            else
            {
                Debug.LogWarning("No valid loot item found!");
            }
        }
        else
        {
            Debug.LogWarning("No loot items defined!");
        }

        
    }

    private LootItem GetRandomLootItem()
    {
        float totalDropPercentage = 0f;

        foreach (LootItem lootItem in lootItems)
        {
            totalDropPercentage += lootItem.dropPercentage;
        }

        float randomValue = Random.Range(0f, totalDropPercentage);

        foreach (LootItem lootItem in lootItems)
        {
            if (randomValue <= lootItem.dropPercentage)
            {
                return lootItem;
            }

            randomValue -= lootItem.dropPercentage;
        }

        return null;
    }

    
}

[System.Serializable]
public class LootItem
{
    public GameObject itemPrefab;
    [Range(0f, 100f)]
    public float dropPercentage;
}
