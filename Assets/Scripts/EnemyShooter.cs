using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float fireRate = 1.5f;
    public float detectionRange = 8f;

    private float fireTimer;
    private Transform player;
    private ObjectPooler pooler;
    private GameLoopManager gameManager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pooler = FindObjectOfType<ObjectPooler>();
        gameManager = FindObjectOfType<GameLoopManager>();
    }

    void Update()
    {
        // ✅ STOP enemy logic if game is paused, menu, game over, or victory
        if (gameManager == null ||
            gameManager.currentState != GameLoopManager.GameState.Playing)
            return;

        if (player == null || pooler == null)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            fireTimer += Time.deltaTime;

            if (fireTimer >= fireRate)
            {
                Shoot();
                fireTimer = 0f;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = pooler.GetBullet();
        if (bullet == null) return;

        bullet.transform.position = transform.position;

        Vector2 dir = player.position - transform.position;
        bullet.GetComponent<Bullet>().Fire(dir);
    }
}