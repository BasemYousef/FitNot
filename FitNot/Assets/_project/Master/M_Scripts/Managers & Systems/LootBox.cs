using AyaOmar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    [HideInInspector] public LootBoxSpawner lootBoxSpawner;

    public LootSystem lootSystem; 
    private bool isTriggered = false;

    private void Start()
    {
        if (lootBoxSpawner == null)
        {
            lootBoxSpawner = GameManager.Instance.GetLootBoxSpawnerRef();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") && !isTriggered)
        {
            Debug.Log("Hit");

            if (lootBoxSpawner != null)
            {
                lootBoxSpawner.OnLootBoxDestroyed(gameObject);
            }

            if (lootSystem != null)
            {
                lootSystem.InstantiateLoot(transform.position);
            }

            isTriggered = true;
            Destroy(gameObject);
        }
    }
}
