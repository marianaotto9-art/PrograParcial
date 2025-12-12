using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 2;
    public int currentHealth;

    private bool isDead = false;
    void Start()
    {
        currentHealth = maxHealth;
    }

   
    public void TakeDamage(int amount)
    {
        if (isDead) return;
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
       
        
        GameManager.Instance.EnemyKilled();
        Destroy(gameObject);
    }
}
