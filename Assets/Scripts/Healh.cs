using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 5; // Default max health value
    private int currentHealth;

    public delegate void OnDeath();
    public event OnDeath onDeath;

    public delegate void OnHealthChanged(int currentHealth, int maxHealth);
    public event OnHealthChanged onHealthChanged;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        onHealthChanged?.Invoke(currentHealth, maxHealth); // Update UI or other systems
    }

    // Call this to reduce health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        onHealthChanged?.Invoke(currentHealth, maxHealth); // Notify UI about health change

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Call this to heal
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        onHealthChanged?.Invoke(currentHealth, maxHealth); // Notify UI about health change
    }

    private void Die()
    {
        onDeath?.Invoke(); // Notify when the object dies
        Destroy(gameObject); // Destroy the object
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetMaxHealth(int value)
    {
        maxHealth = value;
        currentHealth = value;
    }
}
