using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AyaOmar;

public class LootSystem : MonoBehaviour
{
    public List<Item> lootList = new List<Item>();

    Item GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<Item> possibleItems = new List<Item>();
        foreach (Item item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }

        if (possibleItems.Count > 0)
        {
            Item droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }

        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        
        Item droppedItem = GetDroppedItem();
        if (droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItem.itemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.name = droppedItem.itemName;
        }
    }
}
