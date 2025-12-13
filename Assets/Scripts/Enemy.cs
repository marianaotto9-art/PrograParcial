using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 2;
    public int currentHealth;
    public Transform Player;
    public float speed = 2f;
    public float chaseDistance = 5f;
    public int damage = 1;
    public float damageCooldown = 1f;

    public float nextDamageTime = 0f;

    private Rigidbody2D rb;

    private bool isDead = false;
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        float distance = Vector2.Distance(transform.position, Player.position);

        if (distance <= chaseDistance)
        {
            Vector2 direction = (Player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;

        }
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

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Time.time >= nextDamageTime)  //Dentro de la colisión de tipo Stay preguntamos si el objeto con el componente Box Collider 2D está sobre un elemento con tag "Player", si es así accedemos al script Health.cs y tomamos el método de TakeDamage para que aplique el cálculo.
        {
            other.GetComponent<PlayerHeath>()?.TakeDamage(damage);
            nextDamageTime = Time.time + damageCooldown;   // Luego acá seteamos un tiempo para recibir daño para que no sea tan rápido todo por cuestión de los fps del juego.
        }
    }

}
