using UnityEngine;

public class P3MoveLeft : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float speed = 15f; // Speed of movement
    private P3PlayerController playerControllerScript; // Reference to the PlayerController script
    private float leftBound = -15f; // Left boundary for the object 
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<P3PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false) // Check if the game is not over
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime); // Move the object to the left
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) // Check if the object has moved past the left boundary
        {
            Destroy(gameObject); // Destroy the object if it has moved past the left boundary
        }
        //else
        //{ Debug.Log("Game Over!"); // Log game over message
        //    Destroy(gameObject); // Destroy the object if the game is over
        //}
    }
}
