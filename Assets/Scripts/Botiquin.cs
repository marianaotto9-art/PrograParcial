using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botiquin : MonoBehaviour
{
    public int health = 2;
    private void OnTriggerEnter2D(Collider2D collision)

    {
        Debug.Log("toque");
        if (collision.CompareTag("Player"))
        {
            Player hp = collision.GetComponent<Player>();

            if (hp != null)
            {
                hp.TakeDamage(-health);
            }
            Destroy(gameObject);
        }
    }

}
