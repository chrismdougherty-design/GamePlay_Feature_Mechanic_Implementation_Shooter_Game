using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public int damage = 10;
    private Vector2 direction;

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

            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}