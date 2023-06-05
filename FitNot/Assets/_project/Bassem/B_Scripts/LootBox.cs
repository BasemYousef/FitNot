using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    [HideInInspector] public LootBoxSpawner lootBoxSpawner;
    [HideInInspector] public LootSystem loot;
    private void Start()
    {
        loot = GetComponent<LootSystem>();
        if (lootBoxSpawner == null)
        {
            lootBoxSpawner = FindObjectOfType<LootBoxSpawner>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            Destroy(gameObject);
            if (lootBoxSpawner != null)
            {
                lootBoxSpawner.OnLootBoxDestroyed(gameObject);
            }
            if (loot != null)
            {
                loot.DestroyBox();
            }
        }

    }

}