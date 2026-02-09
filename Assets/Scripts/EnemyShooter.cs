using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float fireRate = 1.5f;
    public float detectionRange = 8f;

    private float fireTimer;
    private Transform player;
    private ObjectPooler pooler;

    void Start()
    {
        pooler = FindObjectOfType<ObjectPooler>();
    }

    void Update()
    {
        if (pooler == null)
            return;

        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p == null) return;
            player = p.transform;
        }

        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= detectionRange)
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

        Bullet b = bullet.GetComponent<Bullet>();
        if (b != null)
            b.Fire(player.position - transform.position);
    }
}