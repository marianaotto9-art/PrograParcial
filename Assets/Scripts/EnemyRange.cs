using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public int life;
    public float speed;
    public int damage;
    public bool died;

    public Transform player;
    public float visionRange;

    public Transform[] waypoints;
    private int indice;

    public float fireRate;
    private float nextFireRate;

    public GameObject bullet;
    public Transform bulletSpawnerEnemy;

    private SpriteRenderer sr;

    void Start()
    {
        player = GameObject.Find("Player")?.transform;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if (player == null || waypoints.Length == 0) return;

        bool onSight = Vector2.Distance(transform.position, player.position) < visionRange;

        if (onSight)
        {
            LookAt(player.position);

            nextFireRate += Time.deltaTime;
            if (nextFireRate >= fireRate)
            {
                Instantiate(bullet, bulletSpawnerEnemy.position, Quaternion.identity);
                nextFireRate = 0;
            }
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        Transform target = waypoints[indice];
        Vector3 dir = (target.position - transform.position).normalized;

        transform.position += dir * speed * Time.deltaTime;
        LookAt(target.position);

        if (Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            indice = (indice + 1) % waypoints.Length;
        }
    }

    void LookAt(Vector3 target)
    {
        if (target.x > transform.position.x)
            sr.flipX = false;
        else
            sr.flipX = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (waypoints == null) return;

        Gizmos.color = Color.red;
        foreach (var w in waypoints)
            if (w != null)
                Gizmos.DrawSphere(w.position, 0.4f);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life <= 0 && !died)
        {
            died = true;
            GameManager.Instance?.EnemyKilled();
            Destroy(gameObject);
        }
    }
}
