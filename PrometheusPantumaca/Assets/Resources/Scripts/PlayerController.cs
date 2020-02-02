using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MOVEMENT_BASE_SPEED = 10;

    public bool grabbingBonfire = false;
    public float speed;
    Rigidbody rb;
    public Vector3 movement;
    public bool walk;
    public Animator anim;
    bool SecureZone = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movement = new Vector3(0, 0, 0);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlarMovimiento();
    }

    private void FixedUpdate()
    {
        rb.velocity = movement;

        if (movement != new Vector3(0, 0, 0))
            anim.SetBool("Walk", true);
        else
            anim.SetBool("Walk", false);

        if (movement.x > 0)
            GetComponent<SpriteRenderer>().flipX = true;

        else if (movement.x < 0)
            GetComponent<SpriteRenderer>().flipX = false;



    }

    private void ControlarMovimiento()
    {
        Vector3 input2D = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        speed = Mathf.Clamp(input2D.magnitude, 0, 1);
        input2D.Normalize();
        movement = input2D * speed * MOVEMENT_BASE_SPEED;
    }

    public bool GetZoneSecure()
    {
        return SecureZone;
    }

    public void SetZoneSecure(bool newZone)
    {
        SecureZone = newZone;
    }
}
