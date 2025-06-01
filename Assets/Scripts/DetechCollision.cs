using UnityEngine;

public class DetechCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        // Initialization code can go here if needed
    }

    void Update()
    {
        // This method is called once per frame
        // You can add code here if you need to update something every frame
    }
    void OnTriggerEnter(Collider other)
  {
    Destroy(other.gameObject);
    }
}
