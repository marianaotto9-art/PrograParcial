using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Obstacles : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 1;
    private bool isActive = false;
    public int direction = 1;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        rb.gravityScale = 0;
        rb.freezeRotation = true;

        rb.velocity = new Vector3(direction * speed, 0);
    }

    private void Update()
    {
        if (isActive)
        {
            rb.velocity = new Vector2(direction * speed, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction *= -1;

        transform.position += new Vector3(direction * 0.1f, 0, 0);
        rb.velocity = new Vector2(direction * speed, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive && other.CompareTag("Player"))
        {
            Player hp = other.GetComponent<Player>();
            if (hp != null)
            {
                hp.TakeDamage(damage);
            }
        }
    }

    public void Activate()
    {
        isActive = true;
     
    }

    public void Deactivate()
    {
        isActive = false;
        GetComponent<Collider2D>().enabled = false;
    }

   

}
