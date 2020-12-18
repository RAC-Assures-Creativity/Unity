using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


public class CharacterMovementMultiplayer : NetworkBehaviour
{
    public float speed = 0.00005f;
    public Vector2 direccion;
    private Vector2 movimiento;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private bool camino;
    public int direccionX;
    public int direccionY;


    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();

    }



    void Update()
    {
        if (!hasAuthority) { return; }
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0)
        {
            if (horizontalInput > 0)
            {
                animator.SetTrigger("Derecha");
            }
            else
            {
                animator.SetTrigger("Izquierda");
            }
            camino = true;
            direccionX = (int)horizontalInput;
            direccionY = 0;
        }
        else if (verticalInput != 0)
        {
            if (verticalInput > 0)
            {
                animator.SetTrigger("Arriba");
            }
            else
            {
                animator.SetTrigger("Abajo");
            }
            camino = false;
            direccionX = 0;
            direccionY = (int)verticalInput;
        }

        movimiento = new Vector2(horizontalInput, verticalInput);


    }

    void FixedUpdate()
    {
        if (!hasAuthority) { return; }

        float horizontalVelocity = movimiento.normalized.x * speed;
        float verticalVelocity = movimiento.normalized.y * speed;
        if (camino)
        {
            rigidbody.velocity = new Vector2(horizontalVelocity, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, verticalVelocity);
        }

    }
}
