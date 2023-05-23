using System.Collections.Generic;
using UnityEngine;

public class LootBoxSpawner : MonoBehaviour
{
    public GameObject lootBoxPrefab;
    public Transform[] spawnPoints; 
    public int maxSpawnedBoxes = 5; 

    private List<GameObject> spawnedBoxes = new List<GameObject>();
    private void Start()
    {
        SpawnLootBoxes();
    }

    private void SpawnLootBoxes()
    {
        for (int i = 0; i < maxSpawnedBoxes; i++)
        {
            
            Transform spawnPoint = GetRandomSpawnPoint();

            
            GameObject newBox = Instantiate(lootBoxPrefab, spawnPoint.position, spawnPoint.rotation);
            spawnedBoxes.Add(newBox);

            
            LootBox lootBox = newBox.GetComponent<LootBox>();
            lootBox.lootBoxSpawner = this;
        }
    }

    public void OnLootBoxDestroyed(GameObject box)
    {
       
        spawnedBoxes.Remove(box);

        
        if (spawnedBoxes.Count < maxSpawnedBoxes)
        {
            Transform spawnPoint = GetRandomSpawnPoint();
            GameObject newBox = Instantiate(lootBoxPrefab, spawnPoint.position, spawnPoint.rotation);
            spawnedBoxes.Add(newBox);

            LootBox lootBox = newBox.GetComponent<LootBox>();
            lootBox.lootBoxSpawner = this;
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        
        while (IsSpawnPointOccupied(spawnPoint))
        {
            spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        }

        return spawnPoint;
    }

    private bool IsSpawnPointOccupied(Transform spawnPoint)
    {
        foreach (GameObject box in spawnedBoxes)
        {
            if (box.transform.position == spawnPoint.position)
            {
                return true;
            }
        }
        return false;
    }
}