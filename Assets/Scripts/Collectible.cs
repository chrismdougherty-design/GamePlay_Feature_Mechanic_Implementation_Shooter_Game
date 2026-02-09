using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int pointValue = 1;
    public float rotationSpeed = 90f; // Degrees per second

    void Update()
    {
        // Rotate the collectible
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player touched this collectible
        if (other.CompareTag("Player"))
        {
            // Find the GameLoopManager
            GameLoopManager manager = FindObjectOfType<GameLoopManager>();

            if (manager != null)
            {
                // Increase the score
                manager.SetScore(pointValue);
                Debug.Log("Collected! Score: " + manager.GetScore());
            }

            // Destroy this collectible
            Destroy(gameObject);
        }
    }
}