using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed;
    public int damage;
    public float lifeTime = 3f;

    Vector3 dir;

    void Start()
    {
        Destroy(gameObject, lifeTime);

        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            dir = (player.transform.position - transform.position).normalized;
        }
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
