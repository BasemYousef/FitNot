using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxSpawner : MonoBehaviour
{
    public GameObject boxPrefab;
    public Transform[] spawnLocations;
    public int numberOfBoxes = 5;
    public float spawnInterval = 5f;

    private int boxesSpawned = 0;
    private List<int> usedSpawnIndexes = new List<int>();

    private void Start()
    {
        StartCoroutine(SpawnBoxes());
    }

    private IEnumerator SpawnBoxes()
    {
        while (boxesSpawned < numberOfBoxes)
        {
            int randomLocationIndex = GetRandomUnusedSpawnIndex();
            if (randomLocationIndex != -1)
            {
                SpawnBox(spawnLocations[randomLocationIndex]);
                usedSpawnIndexes.Add(randomLocationIndex);
            }
            else
            {
                Debug.Log("No available spawn locations left!");
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private int GetRandomUnusedSpawnIndex()
    {
        List<int> unusedSpawnIndexes = new List<int>();
        for (int i = 0; i < spawnLocations.Length; i++)
        {
            if (!usedSpawnIndexes.Contains(i))
            {
                unusedSpawnIndexes.Add(i);
            }
        }

        if (unusedSpawnIndexes.Count > 0)
        {
            int randomIndex = Random.Range(0, unusedSpawnIndexes.Count);
            return unusedSpawnIndexes[randomIndex];
        }

        return -1; // Return -1 if all spawn locations have been used
    }

    private void SpawnBox(Transform spawnLocation)
    {
        Instantiate(boxPrefab, spawnLocation.position, Quaternion.identity);
        boxesSpawned++;
    }
}
