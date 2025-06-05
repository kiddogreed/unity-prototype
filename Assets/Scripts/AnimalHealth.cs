using UnityEngine;
using UnityEngine.UI;

public class AnimalHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public GameObject hungerBarPrefab; // Assign your Slider prefab in the Inspector
    private Slider hungerBar;
    private Canvas hungerCanvas;

    void Start()
    {
        currentHealth = maxHealth;

        // Instantiate the hunger bar as a child of the animal
        if (hungerBarPrefab != null)
        {
            GameObject barObj = Instantiate(hungerBarPrefab, transform);
            hungerBar = barObj.GetComponentInChildren<Slider>();
            hungerCanvas = barObj.GetComponentInChildren<Canvas>();

            // Optionally, position the bar above the animal
            barObj.transform.localPosition = new Vector3(0, 2f, 0); // Adjust Y as needed
            if (hungerBar != null)
            {
                hungerBar.maxValue = maxHealth;
                hungerBar.value = currentHealth;
            }
        }
    }

    public bool TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (hungerBar != null)
        {
            hungerBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            return true; // Indicate the animal was destroyed
        }
        return false; // Animal still alive
    }
}