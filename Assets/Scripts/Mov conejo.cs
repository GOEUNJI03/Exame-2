using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Movconejo : MonoBehaviour
{
    private bool movInicial = true;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Mov(2.5f));
        if (rb.velocity.y == 0)
        {
            StartCoroutine(Jump(1.5f));
        }
        do
        {
            transform.Translate(-1, 0, 0);
            StartCoroutine(Mov(2.5f));
        } while (movInicial);
        StartCoroutine(MovOff(2.5f));
        do
        {
            transform.Translate(1, 0, 0);
        } while (movInicial == false);
    }
    IEnumerator Mov(float Tiempo)
    {
        yield return new WaitForSeconds(1);
        movInicial = false;
    }
    IEnumerator MovOff(float Tiempo)
    {
        yield return new WaitForSeconds(1);
        movInicial = true;
    }
    IEnumerator Jump(float Tiempo)
    {
        yield return new WaitForSeconds(1);
        rb.AddForce(new Vector2(0f, 15f), ForceMode2D.Impulse);
    }
}
