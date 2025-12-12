using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velMovimiento = 5f;
    private Rigidbody2D rb;
    private Vector3 movimiento;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movimiento = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f); movimiento.Normalize();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(movimiento.x, movimiento.y) * velMovimiento * Time.deltaTime);
    }
}
