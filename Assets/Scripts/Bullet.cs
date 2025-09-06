using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float timeDestroy;
    AudioSource aus;
    public AudioClip hitSound;

    GameController m_gc;
    public GameObject hitVFX;

    Player player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        aus = FindObjectOfType<AudioSource>();
        Destroy(gameObject, timeDestroy);

        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        rb.velocity = Vector2.up * speed;

        if (m_gc.GetScore() > 15)
        {
            speed = 15;
        }
        if (m_gc.GetScore() > 25)
        {
            speed = 20;
        }
        if (m_gc.GetScore() > 35)
        {
            speed = 30;
        }
        if (m_gc.GetScore() > 45)
        {
            speed = 45;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health enemyHealth = collision.GetComponent<Health>(); // Get the Health component

        if (enemyHealth != null && collision.CompareTag("Enemy"))
        {
            enemyHealth.TakeDamage(player.GetDamage()); // Deal 1 damage to the enemy

            if (aus && hitSound)
            {
                aus.PlayOneShot(hitSound);
            }

            if (hitVFX != null)
            {
                Instantiate(hitVFX, collision.transform.position, Quaternion.identity);
            }
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
