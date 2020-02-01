using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MOVEMENT_BASE_SPEED = 10;


    public bool grabingBonfire = false;
    public float speed;
    Rigidbody2D rb;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        ControlarMovimiento();
    }

    private void FixedUpdate()
    {
        rb.velocity = movement;
    }

    private void ControlarMovimiento()
    {
        Vector2 input2D = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        speed = Mathf.Clamp(input2D.magnitude, 0, 1);
        input2D.Normalize();
        movement = input2D * speed * MOVEMENT_BASE_SPEED;
    }
}
