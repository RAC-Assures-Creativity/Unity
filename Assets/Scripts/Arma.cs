using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject balaPrefab;
    public GameObject shooter;
    private Transform _firePoint;
    private MovimientoPersonaje movimiento;
    private bool presiono;


    void Awake()
    {
        _firePoint = transform.Find("Firepoint");
    }

    // Start is called before the first frame update
    void Start()
    {
        movimiento = FindObjectOfType<MovimientoPersonaje>();   
    }

    // Update is called once per frame
    void Update()
    {
        float attackInput = Input.GetAxisRaw("Jump");
        if(attackInput > 0)
        {
            Shoot();
            presiono = true;
        }
        else
        {
            presiono = false;
        }
    }

    void Shoot()
    {
        if(!presiono && balaPrefab != null && _firePoint != null)
        {
            GameObject miBala = Instantiate(balaPrefab, _firePoint.position, Quaternion.identity) as GameObject;
            Bala balaComponente = miBala.GetComponent<Bala>();

            if (movimiento.direccionX != 0)
            {
                if (movimiento.direccionX > 0)
                {
                    balaComponente.direccion = Vector2.right;
                }
                else
                {
                    balaComponente.direccion = Vector2.left;
                }
            }
            else
            {
                if (movimiento.direccionY > 0)
                {
                    balaComponente.direccion = Vector2.up;
                }
                else
                {
                    balaComponente.direccion = Vector2.down;
                }
            }
        }
    }
}
