using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class Mov_Enemigo : MonoBehaviour
{
    [SerializeField] private float velMovimiento;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private bool seleccion = true;
    [SerializeField] private bool flip = false;
    private Animator anim;

    private int numeroAleatorio;
    //private SpriteRenderer spriteRenderer;

    private void Start()
    {
        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        //spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //Girar();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[numeroAleatorio].position, velMovimiento * Time.deltaTime);

        if (Vector2.Distance(transform.position, puntosMovimiento[numeroAleatorio].position) < distanciaMinima)
        {
            numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
            if (seleccion)
            {
                //Girar();
            }
            else
            {
                GirarPlanta();
            }
        }
    }

    /*private void Girar()
    {
        if (transform.position.x < puntosMovimiento[numeroAleatorio].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }*/
    private void GirarPlanta()
    {
        if (transform.position.x < puntosMovimiento[numeroAleatorio].position.x)
        {
            //spriteRenderer.flipX = true;
            if (flip)
            {
                anim.Play("EnemyXY");
            }
            else
            {
                anim.Play("EnemyXYFlip");
            }
        }
        else
        {
            //spriteRenderer.flipX = false;
            if (flip)
            {
                anim.Play("EnemyXYFlip");
            }
            else
            {
                anim.Play("EnemyXY");
            }
        }
    }
}
