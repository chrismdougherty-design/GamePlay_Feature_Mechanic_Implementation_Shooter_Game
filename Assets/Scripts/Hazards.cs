using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int damageAmount = 20;
    public float rotationSpeed = 90f; // Degrees per second

    void Update()
    {
        // Rotate the hazard
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Get PlayerHealth component from the player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // If found, apply damage
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}