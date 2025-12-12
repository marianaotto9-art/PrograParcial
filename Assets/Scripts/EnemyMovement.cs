using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    public float speed = 2f;
    public float chaseDistance = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
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
}
