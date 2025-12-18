using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class Obstacles : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 1;
    public Transform[] waypoints;

    private int index;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        Vector3 target = waypoints[index].position;
        Vector3 dir = (target - transform.position).normalized;

        transform.position += dir * speed * Time.deltaTime;

        // Flip visual
        if (dir.x > 0)
            sr.flipX = false;
        else if (dir.x < 0)
            sr.flipX = true;

        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            index++;
            if (index >= waypoints.Length)
                index = 0;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>()?.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (waypoints == null) return;

        Gizmos.color = Color.magenta;
        foreach (var p in waypoints)
        {
            if (p != null)
                Gizmos.DrawSphere(p.position, 0.25f);
        }
    }


}

