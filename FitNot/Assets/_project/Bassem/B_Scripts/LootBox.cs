using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    [HideInInspector] public LootBoxSpawner lootBoxSpawner;
    [HideInInspector] public LootSystem loot;
    private bool isTriggered = false;

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
        if (other.CompareTag("Weapon") && isTriggered == false)
        {
            Debug.Log("hit" + gameObject.GetInstanceID());

            if (lootBoxSpawner != null)
            {
                lootBoxSpawner.OnLootBoxDestroyed(gameObject);
            }
            if (loot != null)
            {
                loot.DestroyBox();
            }
            isTriggered = true;
            Destroy(gameObject);
        }
       
    }

}