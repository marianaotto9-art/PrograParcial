using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;
    public float damageCooldown = 1f;

    public float nextDamageTime = 0f;


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Time.time >= nextDamageTime)  //Dentro de la colisión de tipo Stay preguntamos si el objeto con el componente Box Collider 2D está sobre un elemento con tag "Player", si es así accedemos al script Health.cs y tomamos el método de TakeDamage para que aplique el cálculo.
        {
            other.GetComponent<PlayerHeath>()?.TakeDamage(damage);
            nextDamageTime = Time.time + damageCooldown;   // Luego acá seteamos un tiempo para recibir daño para que no sea tan rápido todo por cuestión de los fps del juego.
        }
    }
}
