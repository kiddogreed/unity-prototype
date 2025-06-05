using UnityEngine;

public class DetechCollision : MonoBehaviour
{
    // Static score variable accessible from anywhere
    public static int score = 0;

    void OnTriggerEnter(Collider other)
    {
        // Check if this is the food prefab and it hits an animal
        if (gameObject.CompareTag("Food") && other.CompareTag("Animal"))
        {
            // Reduce animal health and check if destroyed
            AnimalHealth animalHealth = other.GetComponent<AnimalHealth>();
            if (animalHealth != null)
            {
                bool destroyed = animalHealth.TakeDamage(1);
                if (destroyed)
                {
                    score++;
                    Debug.Log("Score: " + score);
                }
            }

            // Destroy the food projectile
            Destroy(gameObject);
        }
    }
}