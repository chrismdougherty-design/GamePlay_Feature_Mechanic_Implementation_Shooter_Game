using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public int damage = 10;
    public float lifeTime = 4f;

    private Vector2 direction;

    void OnEnable()
    {
        Invoke(nameof(ReturnToPool), lifeTime);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    public void Fire(Vector2 dir)
    {
        direction = dir.normalized;
        gameObject.SetActive(true);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
                health.TakeDamage(damage);

            ReturnToPool();
        }
    }

    void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
