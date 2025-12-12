using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public Obstacles[] BooksToStop;
    private bool pressed = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!pressed && other.CompareTag("Player")) // Sólo el player puede acceder comprobando si el Player es quien está dentro del collider del botón
        { 
            pressed = true;

            foreach (Obstacles obst in BooksToStop) // Recorre todos los obstáculos que están generados
            {
                if (obst != null)
                { 
                    obst.Deactivate(); // Accede a la clase Obstacles para desactivar el movimiento de los obstáculos
                }
            }
        }
    }
}
