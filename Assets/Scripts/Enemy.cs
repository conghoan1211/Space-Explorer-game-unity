using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rd;
    public GameObject healthPickup; // Thêm prefab của Health Pickup

    GameController m_gc;
    private Health enemyHealth;

    private bool hasIncreasedAt8 = false; // Cờ cho điểm 8
    private bool hasIncreasedAt15 = false; // Cờ cho điểm 15
    private bool hasIncreasedAt25 = false; // Cờ cho điểm 25
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();

        enemyHealth = GetComponent<Health>(); // Attach Health script
        enemyHealth.onDeath += OnEnemyDeath; // Subscribe to death event
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gc.IsStartGame() == false)
        {
            return;
        }
        rd.velocity = Vector2.down * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadZone"))
        {
            enemyHealth.TakeDamage(enemyHealth.GetCurrentHealth()); // Destroy on reaching DeadZone
            Player player = FindObjectOfType<Player>(); // Tìm đối tượng Player
            if (player != null)
            {
                Health playerHealth = player.GetComponent<Health>(); // Lấy Health của Player
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(1); // Giảm 1 máu của Player
                }
            }
        }
    }

    private void OnEnemyDeath()
    {
        m_gc.ScoreIncreament(); // Gọi hàm tăng điểm

        float randomChance = Random.Range(0f, 1f); // Tạo một giá trị ngẫu nhiên từ 0 đến 1
        if (randomChance <= 0.1f) // 30% cơ hội
        {
            if (healthPickup != null)
            {
                Instantiate(healthPickup, transform.position, Quaternion.identity); // Tạo HealthPickup
            }
        }
        Destroy(gameObject); // Destroy the enemy when health reaches zero
    }
}
