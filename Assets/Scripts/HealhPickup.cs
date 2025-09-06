using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealhPickup : MonoBehaviour
{
    public int healAmount = 1; // Lượng máu hồi
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1; // Cho phép vật phẩm rơi xuống
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount); // Tăng máu cho player
            }

            Destroy(gameObject); // Xóa cục máu sau khi sử dụng
        }

        if (collision.CompareTag("DeadZone"))
        {
            Destroy(gameObject); // Xóa cục máu sau khi sử dụng
        }
    }

}
