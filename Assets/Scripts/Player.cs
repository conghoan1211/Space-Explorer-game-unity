using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float leftBoundary;  // Giới hạn bên trái
    [SerializeField] float rightBoundary;  // Giới hạn bên phải
    [SerializeField] float bottomBoundary; // Giới hạn dưới
    [SerializeField] float topBoundary;     // Giới hạn trên

    public float moveSpeed;
    public GameObject bullet;
    public Transform shootPoint;
    public AudioSource aus;
    public AudioClip shootingSound;

    private Health playerHealth;
    private UIManager m_uiManager; // Reference to UIManager

    private int damage = 1;

    GameController m_gc;
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
        m_uiManager = FindObjectOfType<UIManager>();
        playerHealth = GetComponent<Health>(); // Attach Health script
        playerHealth.onDeath += OnPlayerDeath; // Subscribe to death event
        playerHealth.onHealthChanged += UpdateHealthUI; // Subscribe to health change event
    }

    // Update is called once per frame
    void Update()
    {

        if (m_gc.IsGameOver())
        {
            return; 
        }
        if (m_gc.IsStartGame() == false)
        {
            return;   
        }
        //float xDir = Input.GetAxisRaw("Horizontal");
        //float yDir = Input.GetAxisRaw("Vertical");

        //if (xDir < 0 && transform.position.x <= -10 || xDir > 0 && transform.position.x > 10) return;

        //transform.position += Vector3.right * moveSpeed * xDir * Time.deltaTime;
        Move();
        Attack();
        LimitMove();
    }

    void Move()
    {
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xPos, yPos, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void LimitMove()
    {
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, leftBoundary, rightBoundary);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, bottomBoundary, topBoundary);

        transform.position = clampedPosition;
    }

    void Shoot()
    {
        if (bullet && shootPoint)
        {
            if (aus && shootingSound)
            {
                aus.PlayOneShot(shootingSound);
            }
            Instantiate(bullet, shootPoint.position, Quaternion.identity);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            playerHealth.TakeDamage(1); // Reduce player health when hit by an enemy
        }
    }
    private void OnPlayerDeath()
    {
        m_gc.SetGameOver(true); // Trigger game over when player dies
    }

    private void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        m_uiManager.UpdateHealthBar(currentHealth, maxHealth); // Update the health UI
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetDamage(int value)
    {
        damage = value; 
    }

}
