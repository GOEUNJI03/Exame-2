using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Movconejo : MonoBehaviour
{
    //private bool movInicial = true;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Jump(1.5f));
    }
    // Update is called once per frame
    void Update()
    {
        
        
            transform.Translate(-0.01f, 0, 0);
        
        /*StartCoroutine(MovOff(2.5f));
        if (movInicial)
        {
            transform.Translate(1, 0, 0);
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "destroy")
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator Mov(float Tiempo)
    {
        yield return new WaitForSeconds(1);
        //movInicial = false;
    }
    IEnumerator MovOff(float Tiempo)
    {
        yield return new WaitForSeconds(1);
        //movInicial = true;
    }
    IEnumerator Jump(float Tiempo)
    {
        yield return new WaitForSeconds(1);
        if(rb.velocity.y == 0)
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
        StartCoroutine(Jump(1.5f));
    }
}
