using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MovimientoPersonaje : MonoBehaviour
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


    void Start()
    {
        
    }
    

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        //float attackInput = Input.GetAxisRaw("Jump");

        if (horizontalInput != 0)
        {
            if (horizontalInput > 0)
            {
                //animator.SetInteger("Movimiento", 4);
                animator.SetTrigger("Derecha");
            }
            else
            {
                //animator.SetInteger("Movimiento", 3);
                animator.SetTrigger("Izquierda");
            }
            //animator.SetInteger("Moverse", (int)horizontalInput * 2);
            //animator.SetBool("Quieto", false);
            camino = true;
            direccionX = (int) horizontalInput;
            direccionY = 0;
        }
        else if (verticalInput != 0)
        {
            if (verticalInput > 0)
            {
                //animator.SetInteger("Movimiento", 1);
                animator.SetTrigger("Arriba");
            }
            else
            {
                //animator.SetInteger("Movimiento", 2);
                animator.SetTrigger("Abajo");
            }
            //animator.SetInteger("Moverse", (int)verticalInput);
            //animator.SetBool("Quieto", false);
            camino = false;
            direccionX = 0;
            direccionY = (int)verticalInput;
        }

        movimiento = new Vector2(horizontalInput, verticalInput);

        
    }

    void FixedUpdate()
    {
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


    void LateUpdate()
    {
        //animator.SetBool("Quieto", movimiento == Vector2.zero);
    }

}
