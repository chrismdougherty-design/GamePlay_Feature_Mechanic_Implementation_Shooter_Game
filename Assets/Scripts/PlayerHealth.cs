using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private GameLoopManager gameManager;

    void Awake()
    {
        currentHealth = maxHealth;
        gameManager = FindObjectOfType<GameLoopManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        gameManager.currentState = GameLoopManager.GameState.GameOver;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}