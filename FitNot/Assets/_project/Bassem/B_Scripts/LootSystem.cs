using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootSystem : MonoBehaviour
{
    public List<LootItem> lootItems;
    public float destroyDelay = 10f;
    private List<GameObject> instantiatedItems = new List<GameObject>();
    private Coroutine destroyTimerCoroutine;

    public void DestroyBox()
    {
        
        float randomValue = Random.Range(0f, 100f);

        foreach (LootItem lootItem in lootItems)
        {
            
            if (randomValue <= lootItem.dropPercentage)
            {
                if (lootItem.itemPrefab != null)
                {
                    Debug.Log("Instantiating loot item: " + lootItem.itemPrefab.name);

                    Vector3 spawnPosition = transform.position;
                    spawnPosition.y = 0.5f;

                 
                    GameObject lootItemObject = Instantiate(lootItem.itemPrefab, spawnPosition, Quaternion.identity);
                    instantiatedItems.Add(lootItemObject);

                    
                    destroyTimerCoroutine = StartCoroutine(DestroyItemsAfterDelay(destroyDelay));
                }
                else
                {
                    Debug.LogWarning("Loot item prefab is null!");
                }

                break;
            }

            randomValue -= lootItem.dropPercentage;
        }

        
        Destroy(gameObject);
    }

    private IEnumerator DestroyItemsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        
        foreach (GameObject item in instantiatedItems)
        {
            if (item != null)
            {
                Destroy(item);
            }
        }

        instantiatedItems.Clear();
    }
}

[System.Serializable]
public class LootItem
{
    public GameObject itemPrefab;
    [Range(0f, 100f)]
    public float dropPercentage;
}
