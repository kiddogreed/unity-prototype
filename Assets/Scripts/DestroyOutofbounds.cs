using UnityEngine;

public class DestroyOutofbounds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float topBound = 30f;
    private float lowerBound = -10f;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
       
            Destroy(gameObject);
        }
    }
}
