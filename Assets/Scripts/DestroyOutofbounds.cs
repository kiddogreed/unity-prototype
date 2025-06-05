using UnityEngine;

public class DestroyOutofbounds : MonoBehaviour
{
    private float topBound = 30f;
    private float lowerBound = -10f;
    private float leftBound = -25f;
    private float rightBound = 25f;

    void Update()
    {
        if (transform.position.z > topBound ||
            transform.position.z < lowerBound ||
            transform.position.x < leftBound ||
            transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
    }
}