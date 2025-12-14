using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
   
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            return;
        }

        EnemyRange enemyRange = collision.GetComponent<EnemyRange>();
        if (enemyRange != null)
        {
            enemyRange.TakeDamage(damage);
        }
    }


}


