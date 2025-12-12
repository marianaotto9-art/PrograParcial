using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBooks : MonoBehaviour
{
    public Obstacles[] BookstoActivate;

    private void OnTriggerEnter2D(Collider2D other) // Es exactamente igual que el bótón de desactivación pero para activar, lo único que cambia es el boolean que permite activarlo.
    {
        if (other.CompareTag("Player"))
        { 
            foreach (Obstacles obst in BookstoActivate)
            {
                if (obst != null)
                {
                    obst.Activate();
                }
            }
        }
    }
}
