using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20.0f;
    private float spawnPosZ = 20.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1f;

    void Start()
    {
        // Fix for CS1026: Correctly close the parentheses in InvokeRepeating  
        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, Random.Range(spawnInterval, 3f));
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard != null && keyboard.sKey.wasPressedThisFrame)
        {
            SpawnRandomAnimal();
        }
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int spawnType = Random.Range(0, 3); // 0 = top, 1 = left, 2 = right  
        Vector3 spawnPosition;
        Quaternion spawnRotation = animalPrefabs[animalIndex].transform.rotation;

        if (spawnType == 1)
        {
            // Left side: spawn at left edge, face right (rotate Y by 90 degrees)  
            spawnPosition = new Vector3(-spawnRangeX, 0, Random.Range(0f, spawnPosZ));
            spawnRotation = Quaternion.Euler(0, 90, 0);
        }
        else if (spawnType == 2)
        {
            // Right side: spawn at right edge, face left (rotate Y by -90 degrees)  
            spawnPosition = new Vector3(spawnRangeX, 0, Random.Range(0f, spawnPosZ));
            spawnRotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            // Top spawn (original behavior)  
            spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            // Use prefab's default rotation  
        }

        Instantiate(animalPrefabs[animalIndex], spawnPosition, spawnRotation);
    }
}