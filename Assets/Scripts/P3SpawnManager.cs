using UnityEngine;

public class P3SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private P3PlayerController playerControllerScript;

    private float spawnDelay;
    private float spawnInterval;

    void Start()
    {
        spawnDelay = Random.Range(2f, 5f);
        spawnInterval = Random.Range(2f, 5f);
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<P3PlayerController>();
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false) // Check if the game is not over
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation); // Spawn the obstacle
        }
        //else
        //{
        //    Debug.Log("Game Over!"); // Log game over message
        //}
    }
}